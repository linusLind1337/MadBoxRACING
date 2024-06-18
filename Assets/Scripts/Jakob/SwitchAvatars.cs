using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchAvatars : MonoBehaviour
{
    [SerializeField] private Image avatar;
    [SerializeField] private Sprite[] avatars;

    private void Start()
    {
        if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player1Turn)
        {
            avatar.sprite = avatars[0];
        }
        else if (GameState.Instance.GetPlayerTurn() == PlayerTurn.Player2Turn)
        {
            avatar.sprite = avatars[1];
        }
    }
}
