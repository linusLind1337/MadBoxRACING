using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Actions/Vector3 Action")]
public class GameActionVector3 : ScriptableObject
{
    public Action<Transform> callActionVector3;

    public void CallActionVector3(Transform transform)
    {
        callActionVector3?.Invoke(transform);
    }
}
