using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private string tagOfPlayer = "Player";
    public GameActionVoid finishLinePassed;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagOfPlayer) && !triggered)
        {
            finishLinePassed.CallActionVoid();
            triggered = true;
        }
    }
}
