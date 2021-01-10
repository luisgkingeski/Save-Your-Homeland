using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public Text continuar;

    public GameObject dia1, dia2, dia3;

    private float timer = 0;

    AsyncOperation async;
    
    
    void Start()
    { 
        StartCoroutine("load");
       dia1.SetActive(true);
       dia2.SetActive(false);
       dia3.SetActive(false);

       

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        timer += Time.deltaTime;

        if (timer >= 15)
        {
            dia1.SetActive(false);
            dia2.SetActive(true);
        }
        if (timer >= 35)
        {
            dia2.SetActive(false);
            dia3.SetActive(true);
        }
       
    }
   
     
    IEnumerator load() {
        
#pragma warning disable 618
        async = Application.LoadLevelAsync("Game");
#pragma warning restore 618
        async.allowSceneActivation = false;
        yield return async;
    }
 
    public void ActivateScene() {
        async.allowSceneActivation = true;
      
    }
   
}
