using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ControllData", menuName = "ControllData", order = 2)]
public class ControllData : ScriptableObject
{
    public List<ControllButton> Buttons;
}
[System.Serializable]
public class ControllButton
{
    public bool left;
    public bool right;
    public bool accelerate;
    public bool _break;
    public Vector3 pos;
}