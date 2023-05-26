using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SwitchDimension : MonoBehaviour
{
    
    [SerializeField] Tilemap platformTilemap;
    [SerializeField] Tilemap darkPlatformTilemap;

    [SerializeField] Tilemap climbingTilemap;
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    

    [Header("Colors")]
    [SerializeField] Color defaultTilemapColor;
    [SerializeField] Color backgroundColor;
    [SerializeField] Color defaultDackgroundColor;
    [SerializeField] Color coinColor;
    [SerializeField] Color defaultCoinColor;
    [SerializeField] Color playerColor;
    [SerializeField] Color defaultPlayerColor;
    [SerializeField] Color spikeColor;
    [SerializeField] Color defaultSpikeColor;
    [SerializeField] Color climbingColor;
    [SerializeField] Color defaultClimbingColor;
    

    bool inLightDimension;
    bool canSwitch;

    CullingMaskController cullingMaskController;

    // Start is called before the first frame update
    void Start()
    {
        inLightDimension = true;
        canSwitch = true;

        cullingMaskController = FindObjectOfType<CullingMaskController>();
        DisableTilemapCollider();
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
        {
            ChangeToDarkDimension();
            cullingMaskController.ShowObjects();
            EnableTilemapCollider();
        }      
        else
        {
            ChangeToLightDimension();
            cullingMaskController.HideObjects();
            DisableTilemapCollider();
        }  
    }

    public void SetInLightDimension()
    {
        inLightDimension = !inLightDimension;
        canSwitch = true;
    }

    private void ChangeToDarkDimension()
    {
        platformTilemap.color = Color.black;
        darkPlatformTilemap.color = Color.black;
        climbingTilemap.color = climbingColor;

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
        platformTilemap.color = defaultTilemapColor;
        climbingTilemap.color = defaultClimbingColor;

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

    private static void DisableTilemapCollider()
    {
        TilemapCollider2D[] tilemapCollider2Ds = FindObjectsOfType<TilemapCollider2D>();
        //Debug.Log(tilemapCollider2Ds.Length);
        foreach (TilemapCollider2D tilemapCollider2D in tilemapCollider2Ds)
        {
            if (tilemapCollider2D.gameObject.CompareTag("Dark"))
            {
                tilemapCollider2D.enabled = false;
            }
            else if(tilemapCollider2D.gameObject.CompareTag("Light"))
            {
                tilemapCollider2D.enabled = true;
            }
        }
    }

    private static void EnableTilemapCollider()
    {
        TilemapCollider2D[] tilemapCollider2Ds = FindObjectsOfType<TilemapCollider2D>();
        //Debug.Log(tilemapCollider2Ds.Length);
        foreach (TilemapCollider2D tilemapCollider2D in tilemapCollider2Ds)
        {
            if (tilemapCollider2D.gameObject.CompareTag("Dark"))
            {
                tilemapCollider2D.enabled = true;
            }
            else if(tilemapCollider2D.gameObject.CompareTag("Light"))
            {
                tilemapCollider2D.enabled = false;
            }
        }
    }
}
