using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Parts", menuName = "Parts", order = 3)]
public class Parts : ScriptableObject
{
    public List<GameObject> viechleBody;
    public List<GameObject> viechleDrivetrain;
    public List<GameObject> viechleWheel;
    public GameObject seat;
    
    public List<GameObject> characterHead;
    public List<GameObject> characterBody;

    
    
    public GameObject selectedViechleBody;
    public int selectedViechleDrivetrain;
    public GameObject selectedViechleWheel;
    public int selectedSeatPosition;

    public GameObject selectedCharacterHead;
    public GameObject selectedCharacterBody;
}