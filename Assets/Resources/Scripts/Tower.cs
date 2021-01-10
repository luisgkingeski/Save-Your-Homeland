using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameObject gps;
    private SonsExternos somCabine;
    private int torre = 0;
    void Start()
    {
        somCabine = GameObject.FindWithTag("TorreControle").GetComponent<SonsExternos>();
        torre = Int32.Parse(gameObject.name);
        EscolherGps();

    }


    private void EscolherGps()
    {
        switch (torre)
        {
            case 1:
            {
                gps = GameObject.FindWithTag("gps1");
                break;
            }
            case 2:
            {
                gps = GameObject.FindWithTag("gps2");
                break;
            }
            case 3:
            {
                gps = GameObject.FindWithTag("gps3");
                break;
            }
            case 4:
            {
                gps = GameObject.FindWithTag("gps4");
                break;
            }
            case 5:
            {
                gps = GameObject.FindWithTag("gps5");
                break;
            }
            case 6:
            {
                gps = GameObject.FindWithTag("gps6");
                break;
            }
            case 7:
            {
                gps = GameObject.FindWithTag("gps7");
                break;
            }
            case 8:
            {
                gps = GameObject.FindWithTag("gps8");
                break;
            }
            case 9:
            {
                gps = GameObject.FindWithTag("gps9");
                break;
            }
            case 10:
            {
                gps = GameObject.FindWithTag("gps10");
                break;
            }
        }
        
        
        
        
    }
    
    
    
    private void OnCollisionEnter(Collision other)
    {
       somCabine.Colisao();
        Destroy(gps);
        GameObject.FindWithTag("TorresDisplay").GetComponent<TorresDisplay>().DestuirTorre();  
        
    }
}