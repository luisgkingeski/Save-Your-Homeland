using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fim : MonoBehaviour
{
#pragma warning disable 108,114
    private AudioSource audio;
#pragma warning restore 108,114
    private AudioClip steps, gun,tiro;
    private float timer;
    private bool tocou1, tocou2, tocou3,tocou4,tocou5,aux;
    public GameObject text;


    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        tocou1 = tocou2 = tocou3 = tocou4 = tocou5 = aux = false;
        audio = GetComponent<AudioSource>();
        steps = Resources.Load<AudioClip>("Sounds/Fim/steps");
        gun = Resources.Load<AudioClip>("Sounds/Fim/gun");
        tiro = Resources.Load<AudioClip>("Sounds/Fim/tiro");
        
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        timer += Time.deltaTime;

        if (timer >= 1 && !tocou1)
        {
            tocou1 = true;
            audio.PlayOneShot(steps);
        }
        
        if (timer >= 2 && !tocou2)
        {
            tocou2 = true;
            audio.PlayOneShot(steps);
        } 
        
        if (timer >= 3 && !tocou3)
        {
            tocou3 = true;
            audio.PlayOneShot(steps);
        }
        
        if (timer >= 4 && !aux)
        {
            aux = true;
            text.SetActive(true);
        }
        
        if (timer >= 7 && !tocou4)
        {
            tocou4 = true;
            audio.PlayOneShot(gun);
        }

        if (timer >= 10 && !tocou5)
        {
            tocou5 = true;
            text.SetActive(false);
            audio.PlayOneShot(tiro);
        }

        if (timer >= 15)
        {
            SceneManager.LoadScene("Menu");
        }
    }

} 
