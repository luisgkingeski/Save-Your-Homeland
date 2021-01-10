using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsExternos : MonoBehaviour
{
#pragma warning disable 108,114
    private AudioSource audio;
#pragma warning restore 108,114

    private AudioClip explosao, colisao;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        CarregarSons();
    }

   

    private void CarregarSons()
    {
        explosao = Resources.Load<AudioClip>("Sounds/Externos/explosao");
   
        colisao = Resources.Load<AudioClip>("Sounds/Externos/colisao");
    }

    public void Explosao()
    {
        audio.PlayOneShot(explosao);
    }
    
    public void Colisao()
    {
        audio.PlayOneShot(colisao);
    }

    public void Stop()
    {
        audio.Stop();
    }
    
    
    
}
