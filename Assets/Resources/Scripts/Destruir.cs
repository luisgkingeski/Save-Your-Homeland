using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public float tempo = 2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,tempo);
       
    }

    // Update is called once per frame
    
    
}
