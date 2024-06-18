using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Actions/Int Action")]
public class GameActionInt : ScriptableObject
{
    public Action<int> callActionInt;

    public void CallActionInt(int value)
    {
        callActionInt?.Invoke(value);
    }
}
