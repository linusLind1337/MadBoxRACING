using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{
    public GameActionVoid action;
    public List<GameObject> show, hide;
        
    private void OnEnable()
    {
        action.callActionVoid += ShowHide;
    }

    private void OnDisable()
    {
        action.callActionVoid -= ShowHide;
    }

    public void ShowHide()
    {
        foreach (GameObject objects in show)
        {
            objects.SetActive(true);
        }

        foreach (GameObject objects in hide)
        {
            objects.SetActive(false);
        }
    }
}
