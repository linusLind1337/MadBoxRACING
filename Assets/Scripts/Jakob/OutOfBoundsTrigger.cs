using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour
{
    [SerializeField] private GameActionVoid actionVoidOutOfBounds;
    [SerializeField] private string playerString = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            actionVoidOutOfBounds.CallActionVoid();
        }
    }
}
