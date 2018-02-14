using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItens : MonoBehaviour {

    private SlotInventory currentSlot;
    public InventoryController inventory;

    private bool fullBau = false;
    public ItemBase item1;
    public ItemBase item2;
    public ItemBase item3;
    private ItemBase itemAux;
    private string nomeItem;    
    public AudioSource nullItem;   // audio dizendo "este bau esta vazio"
    public AudioSource audioInformation;  // audio dizendo "você encontrou um bau"
    public AudioSource encontrouBau; // audio dizendo "você encontrou um bau"
    bool isActiveBau = false;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && isActiveBau == true)
        {            
            if (Input.GetKeyDown(KeyCode.Space) && fullBau == true)
            {
                foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
                {
                    if (objeto.tag != "Som")
                    {
                        objeto.Stop();
                        nullItem.Play();
                    }
                }                
                return;
            }
            encontrouBau.Play();
            currentSlot = inventory.selectSlot();            
            Debug.Log("Encontrou baú");
            itemAux = findItem();
            itemAux.getAudioNome().PlayDelayed(2); // informa o item achado
            currentSlot.setItemSlot(itemAux);
            Debug.Log("Você encontrou " + itemAux.getNome());
            inventory.addItemSlot(itemAux, currentSlot); 
        }
    }

    private void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player") && isActiveBau == false)
        {

            foreach (AudioSource objeto in Object.FindObjectsOfType(typeof(AudioSource)))
            {
                if (objeto.tag != "Som")
                {
                    objeto.Stop();
                    audioInformation.Play();
                }
            }            
            isActiveBau = true;
        }
    }

    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            audioInformation.Stop();
            isActiveBau = false;
        }
    }

    private ItemBase findItem()
    {
        int aux = Random.Range(0, 3);        
        if (fullBau == false)
        {
            if (aux == 0)
            {
                fullBau = true;                
                return item1;
            }
            if (aux == 1)
            {
                fullBau = true;                
                return item2;
            }
            else
            {
                fullBau = true;                
                return item3;
            }            
        }        
        return null;
    }

    
}
