using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private GameActionVoid actionVoidLevelFinishedLoading;
    [SerializeField] private GameActionVoid actionVoidRaceStarted;
    [SerializeField] private GameActionVoid actionVoidCountdownStart;
    [SerializeField] private GameActionInt actionIntCountdownStep;
    [SerializeField] private GameActionInt actionIntDelayUntilButton;
    [SerializeField] private GameActionVoid actionVoidCountdownFinished;

    [SerializeField] private GameActionVoid actionVoidCountdownRed;
    [SerializeField] private GameActionVoid actionVoidCountdownYellow;
    [SerializeField] private GameActionVoid actionVoidCountdownGreen;

    
    private bool inputRecieved = false;
    [SerializeField] private int delayBetweenLights;
    [SerializeField] private int delayBeforeButton;
    private int startlightIndex;
    [SerializeField] private GameObject[] startLights;
    [SerializeField] private Button startButton;
    
    private void OnEnable()
    {
        actionVoidLevelFinishedLoading.callActionVoid += StartCountdown;
        actionVoidRaceStarted.callActionVoid += RemoveCubes;
        actionVoidCountdownStart.callActionVoid += StartCountdown;
    }

    private void OnDisable()
    {
        actionVoidLevelFinishedLoading.callActionVoid -= StartCountdown;
        actionVoidRaceStarted.callActionVoid -= RemoveCubes;
        actionVoidCountdownStart.callActionVoid -= StartCountdown;


    }

    private void Start()
    {
        startButton.gameObject.SetActive(false);
        foreach (var light in startLights)
        {
            light.SetActive(false);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player1Turn)
            {
                return;
            }
            if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player2Turn)
            {
                actionVoidCountdownStart.CallActionVoid();
            }
        }
        else
        {
            actionVoidCountdownStart.CallActionVoid();
        }
    }
    
    //Starts the countdown, taking delayBetweenLights as the number of seconds between the showing of each start light
    //The function to show one light calls the function to show the next after delayBetweenLights seconds
    private void StartCountdown()
    {
        StartCoroutine(RedLightOn(delayBetweenLights));
    }

    IEnumerator RedLightOn(int delay)
    {
        yield return new WaitForSeconds(delay);
        startLights[0].SetActive(true);
        actionVoidCountdownRed.CallActionVoid();
        StartCoroutine(YellowLightOn(delayBetweenLights));
    }

    IEnumerator YellowLightOn(int delay)
    {
        yield return new WaitForSeconds(delay);
        startLights[1].SetActive(true);
        actionVoidCountdownYellow.CallActionVoid();
        StartCoroutine(GreenLightOn(delayBetweenLights));
    }

    //The final light instead calls the function to show the start button
    IEnumerator GreenLightOn(int delay)
    {
        yield return new WaitForSeconds(delay);
        startLights[2].SetActive(true);
        actionVoidCountdownGreen.CallActionVoid();
        StartCoroutine(EnableButton(delayBeforeButton));
    }

    IEnumerator EnableButton(int delay)
    {
        yield return new WaitForSeconds(delay);
        startButton.gameObject.SetActive(true);
    }

    //This function fires the Race Started Action which enables the ghost recorder and unfreezes the player
    public void StartRace()
    {
        actionVoidRaceStarted.CallActionVoid();
    }

    //Removes the start lights from the track after the race has started
    private void RemoveCubes()
    {
        foreach (var startLight in startLights)
        {
            startLight.SetActive(false);
        }
    }
}
