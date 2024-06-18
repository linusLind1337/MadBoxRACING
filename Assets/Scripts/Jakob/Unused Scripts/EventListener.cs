using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//This is unused!
public class EventListener : MonoBehaviour
{
    public GameActionVoid finishLinePassed;
    [SerializeField] private GameObject orangeCube;
    [SerializeField] private TMP_Text timerUI;
    private float time;
    private bool timerRunning = true;
    public ReplayManager replayManager;
    private void Start()
    {
        finishLinePassed.callActionVoid += FinishLinePassed;
    }

    private void OnGUI()
    {
        if (timerRunning)
        {
            UpdateTimer();
        }
    }

    private void FixedUpdate()
    {
        time = time += Time.fixedDeltaTime;
    }

    private void FinishLinePassed()
    {
        timerRunning = false;
        //Disable inputs
        //Save time to LevelData
        //Show option to move to next level
    }
    
    
    private string FormatTimer(float time)
    {
        var min = Mathf.FloorToInt(time / 60f);
        var sec = Mathf.FloorToInt(time - min * 60);
        var strTime = $"{min:00}:{sec:00}";
        return strTime;
    }

    private void UpdateTimer()
    {
        timerUI.text = "Timer: " + FormatTimer(time);
    }
}
