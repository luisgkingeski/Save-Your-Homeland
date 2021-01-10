using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllTower : MonoBehaviour
{
    private List<GameObject> jatosAtivos;
    private SonsPainel _sonsPainel;
    private SomJato _somJato;
#pragma warning disable 108,114
    private AudioSource audio;
#pragma warning restore 108,114
    private GameObject jatoControlado;
    private int numeroJatoControlado;
    private GameObject jato1, jato2, jato3;
    private int comando = 0;
    private bool kamiJat1, kamiJat2, kamiJat3;
    //painel
    //kamizake
    private Animator kamizakeAnim,troca1anim,troca2anim,troca3anim;
    private Image kamizakeImg;
    private Sprite kamizakeBlack, kamizakeRed;
    //D-pad
    private Image dPadImg;
    private Sprite dPad,dPadCima, dPadBaixo,dPadDireita,dPadEsquerda,dPadCentro;
    //botoes velocidade
    private Animator maisVelAnim, menosVelAnim;
    //novo jato
    private Animator novoJato;
    //radar
    private Animator radarAnim;

    private GameObject radarObj;

    private int jatosMortos = 0;
    
    
    
    //monitor
    private Monitor monitor1, monitor2, monitor3;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        _sonsPainel = GetComponent<SonsPainel>();
        _somJato = transform.GetChild(0).GetComponent<SomJato>();
        kamiJat1 = kamiJat2 = kamiJat3 = false;
        CarregarPainel();
        troca1anim.SetBool("trocar",true);
        numeroJatoControlado = 1;
        //carregar jatos
        jato1 = Resources.Load<GameObject>("Prefabs/jato1");
        jato2 = Resources.Load<GameObject>("Prefabs/jato2");
        jato3 = Resources.Load<GameObject>("Prefabs/jato3");
        jatosAtivos = new List<GameObject>();
        BuscarJatosAtivos();
        jatoControlado = jatosAtivos[0];
        
    }
    private void CarregarPainel()
    {
        kamizakeAnim = GameObject.FindWithTag("kamikazeAlavanca").GetComponent<Animator>(); 
        kamizakeImg = GameObject.FindWithTag("kamikazeText").GetComponent<Image>();
        kamizakeBlack = Resources.Load<Sprite>("Images/kamikazeBlack");
        kamizakeRed = Resources.Load<Sprite>("Images/kamikazeRed");
        kamizakeImg.sprite = kamizakeBlack;
        
        dPadImg = GameObject.FindWithTag("dPad").GetComponent<Image>();
        dPad = Resources.Load<Sprite>("Images/dpad");
        dPadCima = Resources.Load<Sprite>("Images/dpad-top");
        dPadBaixo = Resources.Load<Sprite>("Images/dpad-down");
        dPadEsquerda = Resources.Load<Sprite>("Images/dpad-left");
        dPadDireita = Resources.Load<Sprite>("Images/dpad-right");
        dPadCentro = Resources.Load<Sprite>("Images/dpad-center");
        dPadImg.sprite = dPad;
        
        troca1anim = GameObject.FindWithTag("trocar1").GetComponent<Animator>(); 
        troca2anim = GameObject.FindWithTag("trocar2").GetComponent<Animator>(); 
        troca3anim = GameObject.FindWithTag("trocar3").GetComponent<Animator>(); 
        //
        maisVelAnim = GameObject.FindWithTag("aumentar").GetComponent<Animator>(); 
        menosVelAnim = GameObject.FindWithTag("diminuir").GetComponent<Animator>();
        
        novoJato = GameObject.FindWithTag("novoJato").GetComponent<Animator>(); 
        
        radarAnim = GameObject.FindWithTag("radar").GetComponent<Animator>();
        radarObj = GameObject.FindWithTag("GPS");
        radarObj.SetActive(false);

        monitor1 = GameObject.FindWithTag("monitor1").GetComponent<Monitor>();
        monitor2 = GameObject.FindWithTag("monitor2").GetComponent<Monitor>();
        monitor3 = GameObject.FindWithTag("monitor3").GetComponent<Monitor>();


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        RodarTorre();
        MoverJatos();

        if (jatosMortos >= 15)
        {
            SceneManager.LoadScene("FimRuim");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    public void Jato1Destruido()
    {
        monitor1.JatoDestruido();
        troca1anim.SetBool("trocar",false);

        if (numeroJatoControlado == 1)
        {
            if (GameObject.FindWithTag("jato2") != null)
            {
                Trocar2();
            }else

            if (GameObject.FindWithTag("jato3") != null)
            {
                Trocar3();  
            }  
        }
       
    }

    public void Jato2Destruido()
    {
        monitor2.JatoDestruido();
        troca2anim.SetBool("trocar",false);

        if (numeroJatoControlado == 2)
        {
            if (GameObject.FindWithTag("jato1") != null)
            {
                Trocar1();
            }else

            if (GameObject.FindWithTag("jato3") != null)
            {
                Trocar3();  
            }
        }
      
    }
    public void Jato3Destruido()
    {
        monitor3.JatoDestruido();
        troca3anim.SetBool("trocar",false);

        if (numeroJatoControlado == 3)
        {
            if (GameObject.FindWithTag("jato1") != null)
            {
                Trocar1();
            }else
       
            if (GameObject.FindWithTag("jato2") != null)
            {
                Trocar2();  
            }   
        }
         
    }
    
    
    
    
  
    
    private void RodarTorre()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y-1,transform.eulerAngles.z);
        }else 
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y+1,transform.eulerAngles.z);
        }
    }
    private void BuscarJatosAtivos()
    {
        jatosAtivos.Add(GameObject.FindWithTag("jato1"));
        jatosAtivos.Add(GameObject.FindWithTag("jato2"));
        jatosAtivos.Add(GameObject.FindWithTag("jato3"));
    }
    public void CenterDpad()
    {
       
        dPadImg.sprite = dPad;
        comando = 0;
    }
    public void MoverJatos()
    {
        switch (comando)
        {
            case 1:
            {
                jatoControlado.GetComponent<Jato>().Cima();
                break;
            }
            case 2:
            {
                jatoControlado.GetComponent<Jato>().Baixo();
                break;
            }
            case 3:
            {
                jatoControlado.GetComponent<Jato>().Esquerda();
                break;
            }
            case 4:
            {
                jatoControlado.GetComponent<Jato>().Direita();
                break;
            }
            case 5:
            {
                jatoControlado.GetComponent<Jato>().Centralizar();
                break;
            }
        }
    }
    public void Cima()
    {
        _sonsPainel.Dpad();
        comando = 1;
        dPadImg.sprite = dPadCima;
    }
    
    public void Baixo()
    {
        _sonsPainel.Dpad();
        comando = 2;
        dPadImg.sprite = dPadBaixo;
    }
    public void Esquerda()
    {
        _sonsPainel.Dpad();
        comando = 3;
        dPadImg.sprite = dPadEsquerda;
    }
    public void Direita()
    {
        _sonsPainel.Dpad();
        comando = 4;
        dPadImg.sprite = dPadDireita;
    }
    public void Centralizar()
    {
        _sonsPainel.Dpad();
        comando = 5;
        dPadImg.sprite = dPadCentro;
    }
    
    public void Aumentar()
    {
        _sonsPainel.DownButton();
        jatoControlado.GetComponent<Jato>().Aumentar();
        if(!maisVelAnim.GetBool("maisVelPress")) maisVelAnim.SetBool("maisVelPress",true);
       
    }
    public void PararAumentar()
    {
        jatoControlado.GetComponent<Jato>().PararAumento();
    }
    public void AumentarButtonReturnAnim()
    {
        _sonsPainel.UpButton();
        maisVelAnim.SetBool("maisVelPress",false);
    }

    
    
    public void Reduzir()
    {
        _sonsPainel.DownButton();
        jatoControlado.GetComponent<Jato>().Reduzir();
        if(!menosVelAnim.GetBool("menosVelPress")) menosVelAnim.SetBool("menosVelPress",true);
    }

    public void PararReduzir()
    {
        jatoControlado.GetComponent<Jato>().PararReduzir();
    }
    
    public void ReduziButtonReturnAnim()
    {
        _sonsPainel.UpButton();
        menosVelAnim.SetBool("menosVelPress",false);
    }
    public void Kamizake()
    {
        _sonsPainel.Kamikaze();
        jatoControlado.GetComponent<Jato>().Kamizake();
        kamizakeImg.sprite = kamizakeRed;
        kamizakeAnim.SetBool("kamizake",true);

        switch (numeroJatoControlado)
        {
            case 1:
            {
                kamiJat1 = true;
                break;
            }
            case 2:
            {
                kamiJat2 = true;
                break;
            }
            case 3:
            {
                kamiJat3 = true;
                break;
            }
        }
    }
    
    public void Trocar1()
    {
       
      _somJato.JatoEngine();
        _sonsPainel.TrocaSom();
        if ( GameObject.Find("jato1") != null)
        {
            jatoControlado = GameObject.FindWithTag("jato1");
            numeroJatoControlado = 1;
            troca1anim.SetBool("trocar",true);
            troca2anim.SetBool("trocar",false);
            troca3anim.SetBool("trocar",false);

            if (!kamiJat1)
            {
                kamizakeAnim.SetBool("kamizake",false);
                kamizakeImg.sprite = kamizakeBlack;
            } else
            {
                kamizakeAnim.SetBool("kamizake",true);
                kamizakeImg.sprite = kamizakeRed;
            }
        }
        
    }
    public void Trocar2()
    {  
       
        _somJato.JatoEngine();
        _sonsPainel.TrocaSom();
        if (GameObject.FindWithTag("jato2") != null)
        {
            jatoControlado = GameObject.FindWithTag("jato2");
            numeroJatoControlado = 2;
            troca2anim.SetBool("trocar",true);
            troca1anim.SetBool("trocar",false);
            troca3anim.SetBool("trocar",false);

            if (!kamiJat2)
            {
                kamizakeAnim.SetBool("kamizake",false);
                kamizakeImg.sprite = kamizakeBlack;
            }
            else
            {
                kamizakeAnim.SetBool("kamizake",true);
                kamizakeImg.sprite = kamizakeRed;
            }  
        }
        
    }
    public void Trocar3()
    {
      
        _somJato.JatoEngine();
        _sonsPainel.TrocaSom();
        if (GameObject.FindWithTag("jato3") != null)
        {
            jatoControlado = GameObject.FindWithTag("jato3");
            numeroJatoControlado = 3;
            troca3anim.SetBool("trocar",true);
            troca1anim.SetBool("trocar",false);
            troca2anim.SetBool("trocar",false);

            if (!kamiJat3)
            {
                kamizakeAnim.SetBool("kamizake",false);
                kamizakeImg.sprite = kamizakeBlack;
            } else
            {
                kamizakeAnim.SetBool("kamizake",true);
                kamizakeImg.sprite = kamizakeRed;
            } 
        }
    }
    
    
    public void NovoJato()
    {
        _sonsPainel.NovoJato();
        novoJato.SetBool("novoJato",true);
        
        if (GameObject.FindWithTag("jato1") == null)
        {
            kamiJat1 = false;
            GameObject jato1Instanciado = Instantiate(jato1, new Vector3(870, 430, -2600), Quaternion.identity);
            jato1Instanciado.name = "jato1";
            jatosAtivos.Clear();
            BuscarJatosAtivos();
            monitor1.ProcurandoJato();
            jatosMortos += 1;
        }
        
        if (GameObject.FindWithTag("jato2") == null)
        {
            kamiJat2 = false;
            GameObject jato2Instanciado = Instantiate(jato2, new Vector3(-2300, 350, 0), Quaternion.Euler(new Vector3(0,90,0)));
            jato2Instanciado.name = "jato2";
            jatosAtivos.Clear();
            BuscarJatosAtivos();
            monitor2.ProcurandoJato();
            jatosMortos += 1;
        }
        
        if (GameObject.FindWithTag("jato3") == null)
        {
            kamiJat3 = false;
            GameObject jato3Instanciado = Instantiate(jato3, new Vector3(850, 470, 1500), Quaternion.Euler(new Vector3(0,180,0)));
            jato3Instanciado.name = "jato3";
            jatosAtivos.Clear();
            BuscarJatosAtivos();
            monitor3.ProcurandoJato();
            jatosMortos += 1;
        }
        
    }

    public void NovoJatoReturnButton()
    {
        novoJato.SetBool("novoJato",false);
    }

    public void Radar()
    {
        _sonsPainel.DownButton();
        radarAnim.SetBool("radar",true);
        radarObj.SetActive(true);
    }
    public void RadarUp()
    {
        _sonsPainel.UpButton();
        radarAnim.SetBool("radar",false); 
        radarObj.SetActive(false);
    }
    
}