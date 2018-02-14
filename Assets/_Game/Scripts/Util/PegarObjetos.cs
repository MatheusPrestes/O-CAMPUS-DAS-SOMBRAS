using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarObjetos : MonoBehaviour {

    public Material material;
    
    // Use this for initialization
	void Start () {
        foreach (GameObject objeto in Object.FindObjectsOfType(typeof(GameObject)))
        {
            if(objeto.tag != "MainCamera" && objeto.GetComponent<SpriteRenderer>()!= null)
            {
                objeto.GetComponent<SpriteRenderer>().material = material;
            }
        }		
	}
	
	
}
