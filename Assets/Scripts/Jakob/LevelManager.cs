using System;
using GhostSystem;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Ghost playerGhost;
    public Rigidbody rbCar;
    [SerializeField] private float force;
    [SerializeField] private GameObject startButton;
    private bool frozen = true;
    public GameObject TutorialUI;
    public GameObject InGameUI;
    
    [SerializeField] private GameActionVoid actionVoidRaceStarted;

    private void OnEnable()
    {
        actionVoidRaceStarted.callActionVoid += RaceStart;
    }    
    private void OnDisable()
    {
        actionVoidRaceStarted.callActionVoid -= RaceStart;
    }

    private void Awake()
    {
        TutorialUI = GameObject.Find("French girl UI");
        InGameUI = GameObject.Find("User Interface");
    }

    //Defaults Ghost to be in idle state
    private void Start()
    {
        playerGhost.currentState = GhostState.Idle;
        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player2Turn && TutorialUI != null)
        {
            TutorialUI.SetActive(false);
        }

        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player1Turn &&
            SceneManager.GetActiveScene().buildIndex == 1)
        {
            InGameUI.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (frozen)
        {
            rbCar.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


    //Starts the recording of the ghost and gives the car a stating boost
    private void RaceStart()
    {
        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player1Turn)
        {
            playerGhost.currentState = GhostState.Recording;
        }

        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player2Turn)
        {
            playerGhost.currentState = GhostState.Replaying;
        }

        frozen = false;
        rbCar.constraints = RigidbodyConstraints.None;
        rbCar.AddForce(-transform.forward * force, ForceMode.Acceleration);
        startButton.SetActive(false);
    }
}
