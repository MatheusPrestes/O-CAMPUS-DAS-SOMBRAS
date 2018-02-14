using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public InventoryController inventory;    
    public GameObject target;
    private Vector3 positionTarget;

    // Use this for initialization
    void Start () {
        inventory.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.I))
        {
           if (GameController.getCurrentState() == GAME_STATE.IN_EXPLORATION && GameController.getCurrentState() != GAME_STATE.IN_DEAD)
            {
                foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
                {
                    if (objeto.tag != "Som")
                    {                        
                        objeto.Stop();
                    }
                }
                GameController.changeState(GAME_STATE.IN_INVENTORY);
                inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);                
                positionTarget = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
                Vector3 tempPosition = Vector3.Lerp(transform.position, positionTarget, 5);
                transform.position = tempPosition;                
            }
           else if(GameController.getCurrentState() == GAME_STATE.IN_INVENTORY)
            {
                foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
                {
                    if (objeto.tag != "Som")
                    {
                        objeto.Stop();
                    }
                }
                inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
                GameController.changeState(GAME_STATE.IN_EXPLORATION);
            }        

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(GameController.getCurrentState() != GAME_STATE.IN_DEAD && ValidaTeclas.getCurrentStateButton() == BUTTON_STATE.IN_DEFFAULT)
            {
                if (GameController.getCurrentState() == GAME_STATE.IN_BATTLE || GameController.getCurrentState() == GAME_STATE.IN_BOSS)
                {                    
                    foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
                    {
                        if (objeto.tag != "Som")
                        {
                            objeto.Stop();
                        }
                    }
                    inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
                    positionTarget = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
                    Vector3 tempPosition = Vector3.Lerp(transform.position, positionTarget, 5);
                    transform.position = tempPosition;
                }
            }    
        }
    }
}
