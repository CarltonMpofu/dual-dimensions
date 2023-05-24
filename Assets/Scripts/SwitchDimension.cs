using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SwitchDimension : MonoBehaviour
{
    [SerializeField] Tilemap myTilemap;
    [SerializeField] Color backgroundColor;
    [SerializeField] Color coinColor;
    [SerializeField] Color playerColor;
    [SerializeField] Color spikeColor;
    [SerializeField] SpriteRenderer playerSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Used by the input system
    void OnSwitch(InputValue value)
    {

        //Debug.Log("Do something");
        myTilemap.color = Color.black;
        Background[] myBackgrounds = FindObjectsOfType<Background>();
        foreach (Background backgroound in myBackgrounds)
        {
            SpriteRenderer spriteRenderer = backgroound.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = backgroundColor;
        }

        Pickup[] myCoins = FindObjectsOfType<Pickup>();
        foreach (Pickup coin in myCoins)
        {
            SpriteRenderer spriteRenderer = coin.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = coinColor;
        }

        Spike[] mySpikes = FindObjectsOfType<Spike>();
        foreach (Spike spike in mySpikes)
        {
            SpriteRenderer spriteRenderer = spike.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = spikeColor;
        }

        playerSpriteRenderer.color = playerColor;
    }
}
