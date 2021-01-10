using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jato : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Vector3 targetAngle ;
    private Vector3 currentAngle;
    Rigidbody m_Rigidbody;
    public bool kamikaze = false;

    private SonsExternos somCabine;
    private GameObject explosion,trail,cam,torre;

    private bool aumentarVelocidade = false;
    private bool reduzirVelocidade = false;

   
    
    // Start is called before the first frame update

   

    void Start()
    {
        torre = GameObject.FindWithTag("TorreControle");
        somCabine = GameObject.FindWithTag("TorreControle").GetComponent<SonsExternos>();
        explosion = transform.GetChild(0).gameObject;
        trail = transform.GetChild(1).gameObject;
        cam = transform.GetChild(2).gameObject;
        
        explosion.SetActive(false);
        m_Rigidbody = GetComponent<Rigidbody>();
        targetAngle = new Vector3(0, transform.eulerAngles.y,0);
        
    }

   
    
    // Update is called once per frame
    void FixedUpdate()
    {
        
        m_Rigidbody.velocity = transform.forward * speed;
        
        if (kamikaze)
        {
          speed += (Time.deltaTime * 10);
        }
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));
 
        transform.eulerAngles = currentAngle;

        if (aumentarVelocidade)
        {
            speed += 1;
        }

        if (reduzirVelocidade)
        {
            if (speed <= 0)
            {
                speed = 0;
            }else speed -= 1;
        }
      
    }

   
    
    
    
    
    
    
    
    
    
    
    public void Cima()
    {
        targetAngle = new Vector3(transform.eulerAngles.x - 25, transform.eulerAngles.y,transform.eulerAngles.z);
    }
    
    public void Baixo()
    {
        targetAngle = new Vector3(transform.eulerAngles.x + 25, transform.eulerAngles.y,transform.eulerAngles.z);
    }
    public void Esquerda()
    {
        targetAngle = new Vector3(transform.eulerAngles.x , transform.eulerAngles.y -25,transform.eulerAngles.z);
    }
    public void Direita()
    {
        targetAngle = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y +25,transform.eulerAngles.z);
    }
    public void Centralizar()
    {
        targetAngle = new Vector3(0, transform.eulerAngles.y ,0);
    }
    
    public void Aumentar()
    {
        reduzirVelocidade = false;
        aumentarVelocidade = true;
    }

    public void PararAumento()
    {
        aumentarVelocidade = false;
    }
    
    
    public void Reduzir()
    {
        aumentarVelocidade = false;
        reduzirVelocidade = true;
    }
    public void PararReduzir()
    {
        reduzirVelocidade = false;
    }
    
    public void Kamizake()
    {
        kamikaze = true;
    }
    
    public void Destruir()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
      
        GetComponent<MeshRenderer>().enabled = false;
        cam.GetComponent<CameraShake>().ShakeCamera(15f, 1f);
        somCabine.Explosao();
        switch (gameObject.name)
        {
            case "jato1":
            {
               torre.GetComponent<ControllTower>().Jato1Destruido();
              
                break;
            }
            case "jato2":
            {
                torre.GetComponent<ControllTower>().Jato2Destruido();
          
                break;
            }
            case "jato3":
            {
                torre.GetComponent<ControllTower>().Jato3Destruido();
               
                break;
            }
        }
      
        m_Rigidbody.velocity = Vector3.zero;
        trail.SetActive(false);
        explosion.SetActive(true); 
        explosion.transform.parent = null;
        Destroy(cam,3);
        Destroy(gameObject,5);

     
    }


    public void ForaDeaAlcance()
    {
        switch (gameObject.name)
        {
            case "jato1":
            {
                torre.GetComponent<ControllTower>().Jato1Destruido();
              
                break;
            }
            case "jato2":
            {
                torre.GetComponent<ControllTower>().Jato2Destruido();
          
                break;
            }
            case "jato3":
            {
                torre.GetComponent<ControllTower>().Jato3Destruido();
               
                break;
            }
        } 
        Destroy(cam,1);
        Destroy(gameObject,2);

    }
    
    
}