using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//The GameStates of this script ended up never being used. Instead I used an enum of only two values, Player1Turn and Player2Turn
//to what logic needed to be different between scene loads.
public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    private GameStates defaultState = GameStates.Default;
    [SerializeField] private PlayerTurn playerTurn = PlayerTurn.Player1Turn;
    [SerializeField] private GameStates previousState = GameStates.Default;
    [SerializeField] private GameStates activeState;
    [SerializeField] private GameActionVoid actionVoidLevelFinishedLoading;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }


    public GameStates GetActiveState()
    {
        return activeState;
    }

    public void UpdateState(GameStates newState)
    {
        previousState = activeState;
        activeState = newState;
    }

    public GameStates GetPreviousState()
    {
        return previousState;
    }

    
    
    
    //Functions to get which player is playing
    public PlayerTurn GetPlayerTurn()
    {
        return playerTurn;
    }

    public void SwitchPlayer()
    {
        if (playerTurn == PlayerTurn.Player1Turn)
        {
            playerTurn = PlayerTurn.Player2Turn;
        }
        else if (playerTurn == PlayerTurn.Player2Turn)
        {
            playerTurn = PlayerTurn.Player1Turn;
        }
    }

    public void DefaultPlayer()
    {
        playerTurn = PlayerTurn.Player1Turn;
    }
}
