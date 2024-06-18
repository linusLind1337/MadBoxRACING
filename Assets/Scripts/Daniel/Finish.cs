using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    //public float time;
    public float basedTime = 0;
    public int basedTimeValue = 0;
    public float points;
    
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;

    public GameActionVoid finished;
    public LevelData levelTime;

    public PlayerInfo playerInfo;

    private void OnEnable()
    {
        finished.callActionVoid += setTime;
    }

    private void OnDisable()
    {
        finished.callActionVoid -= setTime;
    }
    
    public void setTime()
    {
        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player1Turn)
        {
            playerInfo.playersList[0].time = levelTime.time;

            points = CalculatePoints(playerInfo.playersList[0].time);
            WriteOut(player1, 0, (int)points);
        }
        else
        {
            playerInfo.playersList[1].time = levelTime.time;
            
            points = CalculatePoints(playerInfo.playersList[0].time);
            WriteOut(player1, 0, (int)points);
            
            points = CalculatePoints(playerInfo.playersList[1].time);
            WriteOut(player2, 1, (int)points);
        }
    }
    public float CalculatePoints(float time)
    {
        return basedTime / time * basedTimeValue;
        
    }

    private void WriteOut(TextMeshProUGUI text, int index, int points)
    {
        text.text = "Time " + playerInfo.playersList[index].time + "        Points " + points;
    }

    private void Update()
    {
        setTime();
    }
}
