using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TorresDisplay : MonoBehaviour
{

    private List<Image> torresLst;
    private Sprite torreVerde, torreRed;

    public GameObject cheat;
    
    private int torres = 10;
    // Start is called before the first frame update
    void Start()
    {
        cheat.SetActive(false);
        torresLst = new List<Image>();
        torreVerde = Resources.Load<Sprite>("Images/torres/torreVerde"); 
        torreRed = Resources.Load<Sprite>("Images/torres/torreRed");
        for (int i = 0; i < 10; i++)
        {
            torresLst.Add(transform.GetChild(i).GetComponent<Image>());
        }
        
    }

    public void DestuirTorre()
    {
        torres--;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.K))
        {
            cheat.SetActive(true);
        }

        if (torres == 0)
        {
            SceneManager.LoadScene("Fim");
        }
    
        switch (torres)
        {
            case 0:
            {
                torresLst[0].sprite = torreRed;
                break;
            }
            case 1:
            {
                torresLst[1].sprite = torreRed;
                break;
            }
            case 2:
            {
                torresLst[2].sprite = torreRed;
                break;
            }
            case 3:
            {
                torresLst[3].sprite = torreRed;
                break;
            }
            case 4:
            {
                torresLst[4].sprite = torreRed;
                break;
            }
            case 5:
            {
                torresLst[5].sprite = torreRed;
                break;
            }
            case 6:
            {
                torresLst[6].sprite = torreRed;
                break;
            }
            case 7:
            {
                torresLst[7].sprite = torreRed;
                break;
            }
            case 8:
            {
                torresLst[8].sprite = torreRed;
                break;
            }
            case 9:
            {
                torresLst[9].sprite = torreRed;
                break;
            }
            
        }
    }
    
   
    
}