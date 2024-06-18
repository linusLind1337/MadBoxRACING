using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Actions/Void Action")]
public class GameActionVoid : ScriptableObject
{
    public Action callActionVoid;

    public void CallActionVoid()
    {
        callActionVoid?.Invoke();
    }
}
