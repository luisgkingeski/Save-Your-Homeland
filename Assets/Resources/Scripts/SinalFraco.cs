using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class SinalFraco : MonoBehaviour
{

    private Material noise;
    private GameObject sinalFraco,aux;
    private Color color;

    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        CarregarSinal();
        noise.mainTextureOffset = Vector2.zero;
        color = noise.color;
        color.a = 0;
        aux.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Limites();
        if (aux.activeInHierarchy)
        {
            noise.mainTextureOffset = new Vector2(noise.mainTextureOffset.x + 0.05f,0);
            color.a += (1 * Time.deltaTime) / 10;
            noise.color = color;
            currentTime += Time.deltaTime;

        }

        if (currentTime >= 10)
        {
            currentTime = 0;
            GetComponent<Jato>().ForaDeaAlcance();
           

        }
    }

   
    private void Limites()
    {
        if (transform.position.x >= 2400 || transform.position.x <= -2400)
        {
            aux.SetActive(true);
        }
        if (transform.position.z >= 2400 || transform.position.z <= -2800)
        {
            aux.SetActive(true);
        }
        if (transform.position.y >= 1200)
        {
            aux.SetActive(true);
        }

        if (transform.position.x <= 2400 && transform.position.x >= -2400
        && transform.position.z <= 2400 && transform.position.z >= -2800
        && transform.position.y <= 1200)
        {
            noise.mainTextureOffset = Vector2.zero;
            color.a = 0;
            aux.SetActive(false); 

        }

        
    }

    private void CarregarSinal()
    {
        switch (gameObject.name)
        {
            case "jato1":
            {
                sinalFraco = GameObject.FindWithTag("sinalFraco1");
             
                break;
            }
            case "jato2":
            {
                sinalFraco = GameObject.FindWithTag("sinalFraco2");
                
                break;
            }
            case "jato3":
            {
                sinalFraco = GameObject.FindWithTag("sinalFraco3");
               
                break;
            }
        }
        aux = sinalFraco.transform.GetChild(0).gameObject;
        noise = aux.transform.GetChild(0).GetComponent<Image>().material;
        noise.mainTextureOffset = Vector2.zero;
    }

    
    
}
