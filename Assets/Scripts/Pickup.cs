using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int pointsForCoinPickup = 50;
    [SerializeField] AudioClip coinPickupSFX;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !wasCollected)
        {
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 0.4f);
            wasCollected = true;
            //Add the coin to the player wallet when collectd
            Wallet wallet = other.GetComponent<Wallet>();
            if(wallet != null)
            {
                wallet.IncrementCoins();
                Destroy(gameObject);
            }
        }
        
    }
}
