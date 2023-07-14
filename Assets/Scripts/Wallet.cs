using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    DisplayCoins displayCoins;

    int coins = 0;

    private void Start() 
    {
        displayCoins = FindObjectOfType<DisplayCoins>();    
    }

    public int GetCoins()
    {
        //return coins;
        ScenePersist scenePersist =  FindObjectOfType<ScenePersist>();
        if(!scenePersist)
            return coins;
        else
            return scenePersist.GetCoins();
    }

    public void IncrementCoins()
    {
        coins++;
        FindObjectOfType<ScenePersist>().IncrementCoinsCollected();
        displayCoins.ShowCoins();
    }

}
