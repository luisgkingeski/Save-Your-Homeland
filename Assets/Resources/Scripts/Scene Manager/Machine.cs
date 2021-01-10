using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    Text txt;
    string story;
#pragma warning disable 108,114
    private AudioSource audio;
#pragma warning restore 108,114
    private AudioClip tecla;
    
#pragma warning disable 649
    [SerializeField] private float delay;
#pragma warning restore 649
    void Awake () 
    {
        audio = GetComponent<AudioSource>();
        tecla = audio.clip;
        txt = GetComponent<Text> ();
        story = txt.text;
        txt.text = "";

        // TODO: add optional delay when to start
        StartCoroutine ("PlayText");
    }

    
    IEnumerator PlayText()
    {
        foreach (char c in story) 
        {
            txt.text += c;
         
            if(c.ToString()  != " ") audio.PlayOneShot(tecla);
           yield return new WaitForSeconds (delay);
        }
    }
}
