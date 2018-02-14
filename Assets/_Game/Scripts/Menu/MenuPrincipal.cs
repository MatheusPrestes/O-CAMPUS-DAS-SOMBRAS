using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public Button bt_menuPrincipal;
    public Button bt_start;
    public Button bt_tutorial;
    public Button bt_exit;
    private int opcao;
    public AudioSource audioBackGround;
    public AudioSource audioNomeDoJogo;    
    public AudioSource audioJogar;
    public AudioSource audioTutorial;
    public AudioSource audioSair;
    private bool tocarAudio = true;

    void Start()
    {
        audioBackGround.Play();
        bt_menuPrincipal.enabled = true;
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (opcao == 1)
            {
                audioJogar.Stop();
                SceneManager.LoadScene("GamePlay");
            }
            if (opcao == 2)
            {
                audioTutorial.Stop();
                SceneManager.LoadScene("MenuTutorial");
            }
            if (opcao == 3)
            {
                audioSair.Stop();                
                Application.Quit();
            }
        }
    }

    public void BT_MenuPrincipal()
    {
        audioNomeDoJogo.Play();
    }

    public void BT_Start()
    {        
        if(tocarAudio==true)
        {
            bt_menuPrincipal.enabled = false;
            audioNomeDoJogo.Stop();
            audioTutorial.Stop();
            audioSair.Stop();
            audioJogar.Play();
            opcao = 1;
        }        
    }

    public void BT_Tutorial()
    {
        if(tocarAudio==true)
        {
            audioNomeDoJogo.Stop();
            audioSair.Stop();
            audioJogar.Stop();
            audioTutorial.Play();
            opcao = 2;
        }                
    }

    public void BT_Exit()
    {
        if (tocarAudio == true)
        {
            audioTutorial.Stop();
            audioJogar.Stop();
            audioSair.Play();
            opcao = 3;
        }
    }
     


   
}
