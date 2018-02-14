using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BUTTON_STATE
{
    IN_DEFFAULT,
    IN_ATAQUE,
    IN_USARITEM,
    IN_FUGIR
}
public class ValidaTeclas : MonoBehaviour {

    private BUTTON_STATE currentState;
    private static BUTTON_STATE nextState;

    public static ValidaTeclas instance;

    void Start () {
        instance = this;
        nextState = BUTTON_STATE.IN_DEFFAULT;
    }
	
	// Update is called once per frame
	void Update () {
        currentState = nextState;
    }

    public static void changeStateButton(BUTTON_STATE newState)
    {
        nextState = newState;
    }

    public static BUTTON_STATE getCurrentStateButton()
    {
        return instance.currentState;
    }
}
