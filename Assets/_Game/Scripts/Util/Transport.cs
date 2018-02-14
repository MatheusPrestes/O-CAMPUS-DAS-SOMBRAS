using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour {

    private Camera _camera;
    public Transform point;

    public AudioSource audioInformation;
    public AudioSource audioNomeInformation;
    private Collider2D outro;
    private bool isActive = false;

    void Start () {
        _camera = Camera.main;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            audioNomeInformation.Play();            
            outro.transform.position = point.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (point == null)
        {
            Debug.Log("Algo errado no point");
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                audioInformation.Play();
                isActive = true;
                outro = other;
            }
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
