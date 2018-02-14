using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class MenuTutorial : MonoBehaviour {

    public Button bt_tutorial;
    public Button bt_movimentacao;
    public Button bt_identificaoSom;
    public Button bt_identificacaoMonstros;
    public Button bt_identificacaoAtaques;
    public Button bt_identificacaoAtalhos;
    public Button bt_identificacaoInventario;
    public Button bt_identificacaoItens;
    public Button bt_retornarMenuPrincipal;
    
    private int opcao;
    private bool menu = false;

    public AudioClip menuTutorial;

    public AudioClip audioMovimentacao;
    public AudioClip audioIdentificarSom;
    public AudioClip audioIdentificarMonstros;
    public AudioClip audioIdentificarAtaques;
    public AudioClip audioIdentificarAtalhos;
    public AudioClip audioIdentificarInventario;
    public AudioClip audioIdentificarItens;
    public AudioClip audioMenuPrincipal;   

    public AudioClip movimentacao;
    public AudioClip identificacaoDosSons;
    public AudioClip identificacaoDosMonstros;
    public AudioClip identificacaoDosAtaques;
    public AudioClip identificacaoDasTeclasAtalhos;  // criar som
    public AudioClip identificacaoDoInventario;
    public AudioClip identificacaoDosItens;

    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        bt_tutorial.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (opcao == 1)
            {
                desabilitarBotoes();
                movimentacaoJogador();                            
            }
            if (opcao == 2)
            {
                desabilitarBotoes();
                identificarSons();
            }
            if (opcao == 3)
            {
                desabilitarBotoes();
                identificarMonstros();
            }
            if (opcao == 4)
            {
                desabilitarBotoes();
                identificarAtaques();
            }
            if (opcao == 5)
            {
                desabilitarBotoes();
                identificarAtalhos();
            }
            if (opcao == 6)
            {
                desabilitarBotoes();
                identificarInventario();
            }
            if (opcao == 7)
            {
                desabilitarBotoes();
                identificarItens();
            }
            if (opcao == 8)
            {
                SceneManager.LoadScene("MenuPrincipal");
            }
        }
        if(Input.GetKeyDown(KeyCode.F7))
        {
            source.Play();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                objeto.Stop();                
            }
            BT_Tutorial();
            abilitarBotoes();            
        }
    }
    
    public void BT_Tutorial()
    {
        source = addAudioSource(menuTutorial);
        source.Play();        
    }

    public void BT_Movimentacao()
    {
        bt_tutorial.enabled = false;
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
        {
            objeto.Stop();
        }
        source = addAudioSource(audioMovimentacao);
        source.Play();        
        opcao = 1;        
    }

    public void BT_IdentificacaoSons()
    {
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                objeto.Stop();                
            }
        source = addAudioSource(audioIdentificarSom);
        source.Play();               
        opcao = 2;        
    }

    public void BT_IdentificacaoMonstros()
    {
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
        {
            objeto.Stop();
        }
        source = addAudioSource(audioIdentificarMonstros);
        source.Play();        
        opcao = 3;        
    }

    public void BT_IdentificacaoAtaques()
    {
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
        {
            objeto.Stop();
        }
        source = addAudioSource(audioIdentificarAtaques);
        source.Play();
        opcao = 4;        
    }

    public void BT_IdentificacaoAtalhos()
    {
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
        {
            objeto.Stop();
        }
        source = addAudioSource(audioIdentificarAtalhos);
        source.Play();
        opcao = 5;        
    }

    public void BT_IdentificacaoInventario()
    {
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
        {
            objeto.Stop();
        }
        source.PlayOneShot(audioIdentificarInventario,4);
        opcao = 6;
    }

    public void BT_IdentificacaoItens()
    {
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
        {
            objeto.Stop();
        }
        source.PlayOneShot(audioIdentificarItens,4);
        opcao = 7;
    }

    public void BT_MenuPrincipal()
    {
        foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
        {
            objeto.Stop();
        }
        source = addAudioSource(audioMenuPrincipal);
        source.Play();
        opcao = 8;        
    }

    public AudioSource addAudioSource(AudioClip audio)
    {
        source.clip = audio;
        source.volume = 1;
        return source;
    }    

    public void movimentacaoJogador()
    {
        source = addAudioSource(movimentacao);
        source.Play();
    }
    public void identificarSons()
    {
        source = addAudioSource(identificacaoDosSons);
        source.Play();
    }

    public void identificarMonstros()
    {
        source = addAudioSource(identificacaoDosMonstros);
        source.Play();
    }

    public void identificarAtaques()
    {
        source = addAudioSource(identificacaoDosAtaques);
        source.Play();
    }

    public void identificarAtalhos()
    {
        source = addAudioSource(identificacaoDasTeclasAtalhos);
        source.Play();
    }

    public void identificarInventario()
    {
        source = addAudioSource(identificacaoDoInventario);
        source.Play();
    }

    public void identificarItens()
    {
        source = addAudioSource(identificacaoDosItens);
        source.Play();
    }

    public void desabilitarBotoes()
    {
        bt_movimentacao.enabled = false;
        bt_identificaoSom.enabled = false;
        bt_identificacaoMonstros.enabled = false;
        bt_identificacaoAtaques.enabled = false;
        bt_identificacaoAtalhos.enabled = false;
        bt_identificacaoInventario.enabled = false;
        bt_identificacaoItens.enabled = false;
        bt_retornarMenuPrincipal.enabled = false;
    }

    public void abilitarBotoes()
    {
        bt_movimentacao.enabled = true;
        bt_identificaoSom.enabled = true;
        bt_identificacaoMonstros.enabled = true;
        bt_identificacaoAtaques.enabled = true;
        bt_identificacaoAtalhos.enabled = true;
        bt_identificacaoInventario.enabled = true;
        bt_identificacaoItens.enabled = true;
        bt_retornarMenuPrincipal.enabled = true;
    }
}
