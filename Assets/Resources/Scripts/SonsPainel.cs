using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsPainel : MonoBehaviour
{
    //carregar Som
    private AudioClip downbutton,upButton,novoJato,trocaSom,dpad,alavanca, kamikazeSom;
#pragma warning disable 108,114
    private AudioSource audio;
#pragma warning restore 108,114
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        CarregarSons();
    }
    private void CarregarSons()
    {
        downbutton = Resources.Load<AudioClip>("Sounds/Painel/downButton");
        upButton = Resources.Load<AudioClip>("Sounds/Painel/upButton");
        novoJato = Resources.Load<AudioClip>("Sounds/Painel/novoJato");
        trocaSom = Resources.Load<AudioClip>("Sounds/Painel/trocaSom");
        dpad = Resources.Load<AudioClip>("Sounds/Painel/dpad");
        kamikazeSom = Resources.Load<AudioClip>("Sounds/Painel/kamikazeSom");
        alavanca = Resources.Load<AudioClip>("Sounds/Painel/alavanca");
        
    }

    public void DownButton()
    {
        audio.PlayOneShot(downbutton);
    }
    public void UpButton()
    {
        audio.PlayOneShot(upButton);
    }
   
    public void NovoJato()
    {
        audio.PlayOneShot(novoJato);
    }
    public void TrocaSom()
    {
        audio.PlayOneShot(trocaSom);
    }
    public void Dpad()
    {
        audio.PlayOneShot(dpad);
    }

    public void Kamikaze()
    {
        audio.PlayOneShot(alavanca);
        audio.PlayOneShot(kamikazeSom);
    }
    
    
    
    
    
}
