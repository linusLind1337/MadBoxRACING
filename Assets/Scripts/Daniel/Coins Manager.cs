using System;
using Unity.VisualScripting;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInfo.coins += value;
            Destroy(this.gameObject);
        }
    }
}
