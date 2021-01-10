using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomGirando : MonoBehaviour
{
#pragma warning disable 108,114
    private AudioSource audio;
#pragma warning restore 108,114

    private AudioClip giro;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        giro = Resources.Load<AudioClip>("Sounds/Painel/giro");
        audio.clip = giro;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            audio.Play();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            audio.Stop();
        }


    }

}
