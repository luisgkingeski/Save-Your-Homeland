using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espaco : MonoBehaviour
{
    private float timer = 0;

    public GameObject espaco;

    public Loading loading;
    // Start is called before the first frame update
    void Start()
    {
        espaco.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 50)
        {
            espaco.SetActive(true);

            if (Input.GetKey(KeyCode.Space))
            {
                loading.ActivateScene();
            }
            
            
        }
    }
}
