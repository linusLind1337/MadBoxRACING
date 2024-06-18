using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "PlayerInfo", order = 4)]
public class PlayerInfo : ScriptableObject
{
    public List<Players> playersList;

    public int playerIndex;
    public int coins;
}

[System.Serializable]
public class Players
{
    public string name;
    public float time;
}
