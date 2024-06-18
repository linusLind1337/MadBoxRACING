using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Actions/Int, Int Action")]
public class GameActionIntInt : ScriptableObject
{
    public Action<int, int> callActionIntInt;

    public void CallActionIntInt(int value1, int value2)
    {
        callActionIntInt?.Invoke(value1, value2);
    }
}
