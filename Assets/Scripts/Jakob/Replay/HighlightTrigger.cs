using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HighlightTrigger : MonoBehaviour
{
    [SerializeField] private string tagOfPlayer = "Player";
    [SerializeField] private int recordDuration;
    [SerializeField] private int cameraIndex;
    public GameActionIntInt actionHighlightPassed;
    private bool highlightRecorded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagOfPlayer) && !highlightRecorded)
        {
            actionHighlightPassed.CallActionIntInt(recordDuration, cameraIndex);
            highlightRecorded = true;
        }
    }
}
