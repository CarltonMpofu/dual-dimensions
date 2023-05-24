using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SwitchDimension : MonoBehaviour
{
    [SerializeField] Tilemap myTilemap;
    [SerializeField] Color defaultTilemapColor;
    [SerializeField] Color backgroundColor;
    [SerializeField] Color defaultDackgroundColor;
    [SerializeField] Color coinColor;
    [SerializeField] Color defaultCoinColor;
    [SerializeField] Color playerColor;
    [SerializeField] Color defaultPlayerColor;
    [SerializeField] Color spikeColor;
    [SerializeField] Color defaultSpikeColor;
    [SerializeField] SpriteRenderer playerSpriteRenderer;

    bool inLightDimension;
    bool canSwitch;

    // Start is called before the first frame update
    void Start()
    {
        inLightDimension = true;
        canSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Used by the input system
    void OnSwitch(InputValue value)
    {
        // if(inLightDimension)
        //     ChangeToDarkDimension();
        // else
        //     ChangeToLightDimension();
        if(canSwitch)
        {
            canSwitch = false;
            FindObjectOfType<ScreenDarkener>().StartDarkeningAnimation();
        }
            

        //Switch();
    }

    public void ChangeDimension()
    {
        if (inLightDimension)
            ChangeToDarkDimension();
        else
            ChangeToLightDimension();
        
    }

    public void SetInLightDimension()
    {
        inLightDimension = !inLightDimension;
        canSwitch = true;
    }

    private void ChangeToDarkDimension()
    {
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

    private void ChangeToLightDimension()
    {
        myTilemap.color = defaultTilemapColor;
        Background[] myBackgrounds = FindObjectsOfType<Background>();
        foreach (Background backgroound in myBackgrounds)
        {
            SpriteRenderer spriteRenderer = backgroound.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = defaultDackgroundColor;
        }

        Pickup[] myCoins = FindObjectsOfType<Pickup>();
        foreach (Pickup coin in myCoins)
        {
            SpriteRenderer spriteRenderer = coin.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = defaultCoinColor;
        }

        Spike[] mySpikes = FindObjectsOfType<Spike>();
        foreach (Spike spike in mySpikes)
        {
            SpriteRenderer spriteRenderer = spike.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = defaultSpikeColor;
        }

        playerSpriteRenderer.color = defaultPlayerColor;
    }
}
