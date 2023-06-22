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
    [SerializeField] Color defaultRockColor;
    [SerializeField] Color defaultMovingPlatformColor;
    

    bool inLightDimension;
    bool canSwitch;

    CullingMaskController cullingMaskController;
    //TileColliderr[] tileColliders;

    // Start is called before the first frame update
    void Start()
    {
        HideHiddenColliders();
        
        inLightDimension = true;
        canSwitch = true;

        cullingMaskController = FindObjectOfType<CullingMaskController>();
        //tileColliders = FindObjectsOfType<TileColliderr>();

        ChangeToLightDimension();
        cullingMaskController.ShowLightObjects();
        EnableLightTilemapCollider2Ds();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Used by the input system
    void OnSwitch(InputValue value)
    {
        if(canSwitch)
        {
            FindObjectOfType<PlayerController>().isActive = false;
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
            cullingMaskController.ShowDarkObjects();
            EnableDarkTilemapCollider2Ds();
        }      
        else
        {
            ChangeToLightDimension();
            cullingMaskController.ShowLightObjects();
            EnableLightTilemapCollider2Ds();
        }  
    }

    public void SetInLightDimension()
    {
        inLightDimension = !inLightDimension;
        canSwitch = true;
        FindObjectOfType<PlayerController>().isActive = true;
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

        Rock[] myRocks = FindObjectsOfType<Rock>();
        foreach (Rock rock in myRocks)
        {
            SpriteRenderer spriteRenderer = rock.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.black;
        }

        MovingPlatform[] myMovingPlatforms = FindObjectsOfType<MovingPlatform>();
        foreach (MovingPlatform myMovingPlatform in myMovingPlatforms)
        {
            SpriteRenderer spriteRenderer = myMovingPlatform.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.black;
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

        Rock[] myRocks = FindObjectsOfType<Rock>();
        foreach (Rock rock in myRocks)
        {
            SpriteRenderer spriteRenderer = rock.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = defaultRockColor;
        }

        MovingPlatform[] myMovingPlatforms = FindObjectsOfType<MovingPlatform>();
        foreach (MovingPlatform myMovingPlatform in myMovingPlatforms)
        {
            SpriteRenderer spriteRenderer = myMovingPlatform.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = defaultMovingPlatformColor;
        }

        playerSpriteRenderer.color = defaultPlayerColor;
    }

    private static void EnableLightTilemapCollider2Ds()
    {
        TilemapCollider2D[] tilemapCollider2Ds = FindObjectsOfType<TilemapCollider2D>();
        foreach (TilemapCollider2D tilemapCollider2D in tilemapCollider2Ds)
        {
            // Disable dark TilemapCollider2Ds
            if (tilemapCollider2D.gameObject.CompareTag("Dark"))
            {
                tilemapCollider2D.enabled = false;
            }
            // Enable light TilemapCollider2Ds
            else if(tilemapCollider2D.gameObject.CompareTag("Light"))
            {
                tilemapCollider2D.enabled = true;
                
            }
        }

        EnableLightHiddenColliders();
    }

    private static void EnableDarkTilemapCollider2Ds()
    {
        TilemapCollider2D[] tilemapCollider2Ds = FindObjectsOfType<TilemapCollider2D>();


        foreach (TilemapCollider2D tilemapCollider2D in tilemapCollider2Ds)
        {
            // Enable dark TilemapCollider2Ds
            if (tilemapCollider2D.gameObject.CompareTag("Dark"))
            {
                tilemapCollider2D.enabled = true;
            }
            // Disable light TilemapCollider2Ds
            else if (tilemapCollider2D.gameObject.CompareTag("Light"))
            {
                tilemapCollider2D.enabled = false;
            }
        }

        EnableDarkHiddenColliders();
    }

    private static void EnableDarkHiddenColliders()
    {
        HiddenCollider[] tileColliders = FindObjectsOfType<HiddenCollider>();
        foreach (HiddenCollider tileCollider in tileColliders)
        {
            if (tileCollider.gameObject.CompareTag("Dark"))
            {
                tileCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                //tileCollider.gameObject.SetActive(true);

            }
            else if (tileCollider.gameObject.CompareTag("Light"))
            {
                tileCollider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //tileCollider.gameObject.SetActive(false);

            }
        }
    }

    private static void EnableLightHiddenColliders()
    {
        HiddenCollider[] tileColliders = FindObjectsOfType<HiddenCollider>();
        foreach (HiddenCollider tileCollider in tileColliders)
        {
            if (tileCollider.gameObject.CompareTag("Dark"))
            {
                tileCollider.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            }
            else if (tileCollider.gameObject.CompareTag("Light"))
            {
                tileCollider.gameObject.GetComponent<BoxCollider2D>().enabled = true;

            }
        }
    }

    /// <summary>
    /// Change the transparency to 0 so the player does not see the gameobjects
    /// </summary>
    private static void HideHiddenColliders()
    {
        HiddenCollider[] tileColliders = FindObjectsOfType<HiddenCollider>();
        foreach (HiddenCollider tileCollider in tileColliders)
        {
            tileCollider.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        }
    }

}
