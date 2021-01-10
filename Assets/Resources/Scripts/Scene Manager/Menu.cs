using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject controles;

    void Start()
    {
        controles.SetActive(false); 
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    
    
    public void Jogar()
    {
        SceneManager.LoadScene("Loading");
    }
    
    public void Controles()
    {
        controles.SetActive(true);
    }

    public void Voltar()
    {
        controles.SetActive(false);
    }
}
