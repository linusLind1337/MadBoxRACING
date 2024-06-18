using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownDisplay : MonoBehaviour
{
    [SerializeField] private GameActionInt actionIntCountdownStep;
    [SerializeField] private GameActionVoid actionVoidRaceStarted;
    [SerializeField] private GameActionVoid actionVoidCountdownFinished;
    [SerializeField] private TMP_Text UIElement;
    [SerializeField] private GameObject[] startLights;

    private void OnEnable()
    {
        actionIntCountdownStep.callActionInt += NextCountdownLight;
        actionVoidRaceStarted.callActionVoid += DebugRaceStarted;
    }

    private void OnDisable()
    {
        actionIntCountdownStep.callActionInt += NextCountdownLight;
        actionVoidRaceStarted.callActionVoid -= DebugRaceStarted;

    }

    private void Start()
    {
        foreach (var t in startLights)
        {
            t.SetActive(false);
        }
    }

    private void NextCountdownLight(int step)
    {
        startLights[step].SetActive(true);
    }

    private void DebugRaceStarted()
    {
        Debug.Log("Race Started!");
    }
}
