using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliderr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Player");
            LevelManager.Instance.ReloadLevel();    
        }
    }
}
