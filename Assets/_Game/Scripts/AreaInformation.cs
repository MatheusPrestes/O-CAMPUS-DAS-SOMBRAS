using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInformation : MonoBehaviour {

    public AudioSource audioInformation;
    public AudioSource informacao;
    bool isActive = false;

    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true &&  GameController.getCurrentState() == GAME_STATE.IN_EXPLORATION)
        {
            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();
                    informacao.Play();
                }               
            }                        
        }        
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {            
            audioInformation.Play();
            isActive = true;            
        }        
    }

    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            audioInformation.Stop();
            isActive = false;
        }
    }




}
