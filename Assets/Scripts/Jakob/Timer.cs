using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameActionVoid finishLinePassed;
    [SerializeField] private GameActionVoid actionVoidRaceStarted;
    [SerializeField] LevelData currentLevelData;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text timeToBeat;
    private float time;
    private bool timerRunning = false;

    private void Start()
    {
        SetTimeToBeat();
    }
    
    private void OnEnable()
    {
        finishLinePassed.callActionVoid += StopTimer;
        actionVoidRaceStarted.callActionVoid += StartTimer;
    }

    private void OnDisable()
    {
        finishLinePassed.callActionVoid -= StopTimer;
        actionVoidRaceStarted.callActionVoid -= StartTimer;
    }

    private void FixedUpdate()
    {
        if (timerRunning)
        {
            time = time += Time.fixedDeltaTime;
        }
    }
    private void OnGUI()
    {
        if (timerRunning)
        {
            UpdateTimer();
        }
    }
    
    private void UpdateTimer()
    {
        timer.text = FormatTimer(time);
    }

    private void StartTimer()
    {
        timerRunning = true;
    }
    
    private string FormatTimer(float time)
    {
        var min = Mathf.FloorToInt(time / 60f);
        var sec = Mathf.FloorToInt(time - min * 60);
        var strTime = $"{min:00}:{sec:00}";
        return strTime;
    }

    private void SetTimeToBeat()
    {
        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player1Turn)
        {
            timeToBeat.text = "-";
        }
        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player2Turn)
        {
            timeToBeat.text = FormatTimer(currentLevelData.time);
        } 
    }

    private void StopTimer()
    {
        timerRunning = false;
        currentLevelData.time = time;
    }
}
