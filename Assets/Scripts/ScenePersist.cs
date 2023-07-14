using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenePersist : MonoBehaviour
{

    int coinsCollectedInScene = 0;
    private void Awake() 
    {
        
        int numberOfPersists = FindObjectsOfType<ScenePersist>().Length; 

        if(numberOfPersists > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }

    public void IncrementCoinsCollected()
    {
        coinsCollectedInScene++;
    }

    public int GetCoins()
    {
        return coinsCollectedInScene;
    }
}
