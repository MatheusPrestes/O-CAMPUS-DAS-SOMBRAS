using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {


    public AudioSource audioGamePlay01;    
    
    // Use this for initialization
	void Start () {
        audioGamePlay01.Play();        
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.F6))
        {
            audioGamePlay01.Stop();
            SceneManager.LoadScene("Mapa1");
        }
        if(!audioGamePlay01.isPlaying)
        {
            SceneManager.LoadScene("Mapa1");
        }
	}    
}
