using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoading : MonoBehaviour {

    private Camera _camera;
    public Transform point;
    public AudioSource audioInformation;
    public AudioSource audioNomeInformation;    
    private Collider2D aux;
    private bool isActive = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            audioNomeInformation.Play();           
            aux.transform.position = point.transform.position;                       
        }		
	}

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            audioInformation.Play();
            isActive = true;
            aux = outro;
        }
    }

    void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            isActive = false;
            audioInformation.Stop();            
        }
    } 
  }
