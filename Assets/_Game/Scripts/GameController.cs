using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAME_STATE
{
    IN_EXPLORATION,
    IN_BATTLE,    
    IN_BOSS,
    IN_INFORMATION,
    IN_INVENTORY,
    IN_HISTORY,
    IN_DEAD    
}

public class GameController : MonoBehaviour {

    private GAME_STATE currentState;
    private static GAME_STATE nextState;   

    public static GameController instance;    

    // Use this for initialization
    void Start () {
        instance = this;
        nextState = GAME_STATE.IN_EXPLORATION;
	}

    void Update()
    {
        currentState = nextState;
        switch (currentState)
        {
            case GAME_STATE.IN_EXPLORATION:
                {
                    break;
                }
            case GAME_STATE.IN_HISTORY:
                {
                    break;
                }
            case GAME_STATE.IN_BATTLE:
                {
                    break;
                }
            case GAME_STATE.IN_BOSS:
                {
                    break;
                }
            case GAME_STATE.IN_INFORMATION:
                {
                    break;
                }
            case GAME_STATE.IN_INVENTORY:
                {
                    break;
                }
            case GAME_STATE.IN_DEAD:
                {
                    break;
                }
        }
    }

    public static void changeState(GAME_STATE newState)
    {
        nextState = newState;        
    }

    public static GAME_STATE getCurrentState()
    {        
        return instance.currentState;
    }

}
