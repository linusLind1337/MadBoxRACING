using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateResetPoint : MonoBehaviour
{
    [SerializeField] private int resetPointIndex;
    [SerializeField] private string tagOfPlayer = "Player";
    public GameActionInt updateResetPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagOfPlayer))
        {
            updateResetPoint.CallActionInt(resetPointIndex);
        }
    }
}
