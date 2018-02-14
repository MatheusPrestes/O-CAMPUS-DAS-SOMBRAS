using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : MonoBehaviour {

    public AudioSource audioSomDeFundo;
    public Player jogador;

    const float distanciaMinima = 200f; // distancia minima pro player começar a ouvir o som // era 80f

    void Start()
    {
        soundBackGround();
    }

    void Update()
    {
        //soundBackGround();
    }

    public void  soundBackGround()
    {
        if(GameController.getCurrentState() == GAME_STATE.IN_EXPLORATION)
        {
            audioSomDeFundo.Play();
        }
        if (GameController.getCurrentState() != GAME_STATE.IN_EXPLORATION)
        {
            Debug.Log("entrou aqui");
            audioSomDeFundo.Stop();
        }
    }

    public void soundAmbient()
    {
        Vector3 posObj = transform.localPosition; // posicao do obj que esta neste script
        Vector3 posJog = jogador.transform.localPosition;    // posicao do jogador

        float distObjJog = Vector3.Distance(posObj, posJog); // diastancia entre jogador e o obj
        //Debug.Log("distancia obj e jogador: " + distObjJog);


        float volume = 1f - Mathf.Clamp(distObjJog / distanciaMinima, 0f, 1f);  // divide a distancia atual entre a minima, tipo, se a distancia atual for 5, faz 5/20 = 0.25, dpois subtrai esse valor de 1, vai ficar 0.75.
        // se a distancia atual for 40, faz 40/20 = 2, o Clamp vai pegar esse 2 e colocar entre 0 e 1, como 2 eh maior que o maximo, que eh 1, deixa em 1, ai tu faz 1 - 1, que eh zero, ou seja,m nao eh pra ouvir o som

        if (distObjJog / 100 < distanciaMinima && !audioSomDeFundo.isPlaying && GameController.getCurrentState() == GAME_STATE.IN_EXPLORATION)
        {
            audioSomDeFundo.Play();
        }

        if (distObjJog / 100 > distanciaMinima && audioSomDeFundo.isPlaying)
        {
            audioSomDeFundo.Stop();
        }

        Debug.Log("volume: " + volume);
        audioSomDeFundo.volume = volume;
    }

    
}
