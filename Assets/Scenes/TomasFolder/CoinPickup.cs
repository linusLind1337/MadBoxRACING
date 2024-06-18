using UnityEngine;
using FMODUnity;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private string coinCollectedEventPath;

    private bool collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            Debug.Log("Coin collected");
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        collected = true;
        gameObject.SetActive(false);
        RuntimeManager.PlayOneShot(coinCollectedEventPath, transform.position);
    }
}
