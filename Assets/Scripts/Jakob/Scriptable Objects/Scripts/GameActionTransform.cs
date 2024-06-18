using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Actions/Transform Action")]
public class GameActionTransform : ScriptableObject
{
    public Action<Transform> callActionTransform;

    public void CallActionTransform(Transform transform)
    {
        callActionTransform?.Invoke(transform);
    }
}
