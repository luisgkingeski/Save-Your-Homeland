using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SomJato : MonoBehaviour
{ 
#pragma warning disable 108,114
    private AudioSource audio;
#pragma warning restore 108,114

    private AudioClip jato;

    // Start is called before the first frame update
    void Start()
    {
        jato = Resources.Load<AudioClip>("Sounds/Externos/jato");
        audio = GetComponent<AudioSource>();
        audio.clip = jato;
    }

    public void JatoEngine()
    {
        audio.Play();
       
    }

}
