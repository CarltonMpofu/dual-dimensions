using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoins : MonoBehaviour
{
    TextMeshProUGUI coinText;
    Goal goal;
    Wallet wallet;


    // Start is called before the first frame update
    void Start()
    {
        wallet = FindObjectOfType<Wallet>();
        goal = FindObjectOfType<Goal>();
        coinText = GetComponent<TextMeshProUGUI>();

        ShowCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCoins()
    {
        coinText.text = $"{wallet.GetCoins()}/{goal.GetCoinTarget()}";
    }
}
