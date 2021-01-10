using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
#pragma warning disable 108,114
    private Material noise, camera;
#pragma warning restore 108,114
    private RawImage img;
    private GameObject procurandoJato;
    private float timerJatoDestruido = 0;
    private float procurandoJatoTimer = 0;
    private bool procurandoJatoActive = false;
    private bool jatoDestruido = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
      
        procurandoJato = transform.GetChild(0).gameObject;
        procurandoJato.SetActive(false);
        noise = Resources.Load<Material>("Materials/noise");
        CarregarCamera();
       
        img = GetComponent<RawImage>();
        img.material = camera;
        img.material.mainTextureOffset = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Noise();
        ProcurandoJatoActive();



    }

    private void CarregarCamera()
    {
        switch (gameObject.name)
        {
            case "cam1":
            {
                camera = Resources.Load<Material>("Materials/camera1");
                break;
            }
            case "cam2":
            {
                camera = Resources.Load<Material>("Materials/camera2");
                break;
            }
            case "cam3":
            {
                camera = Resources.Load<Material>("Materials/camera3");
                break;
            }
        }

    }
    
private void Noise()
{
    if (img.material == noise)
    {
        img.material.mainTextureOffset = new Vector2(img.material.mainTextureOffset.x + 0.05f,0); 
             
    }else   img.material.mainTextureOffset = Vector2.zero;

    

    if (jatoDestruido)
    {
        timerJatoDestruido += Time.deltaTime;
    }

    if (timerJatoDestruido >= 3)
    {
        jatoDestruido = false;
        timerJatoDestruido = 0;
        img.material = noise;
    }  
}

private void ProcurandoJatoActive()
{
    if (procurandoJatoActive)
    {
        procurandoJatoTimer += Time.deltaTime;
    }

    if (procurandoJatoTimer >= 2)
    {
        procurandoJatoActive = false;
        procurandoJato.SetActive(false);
        procurandoJatoTimer = 0;
        img.material = camera;
    }
}

    public void JatoDestruido()
    {
        jatoDestruido = true;
        
    }


    public void ProcurandoJato()
    {
        procurandoJatoActive = true;
        procurandoJato.SetActive(true);
    }
}
