using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] int target;
    [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color unlockColor = Color.blue;
    [SerializeField] Vector2 jumpForce = new Vector2(0f, 30);
    
    SpriteRenderer spriteRenderer;
    Wallet playerWallet;

    GameSession gameSession;

    BlinkingText blinkingText;

    PlayerController playerController;

    bool isUnlocked;
    bool isDone;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        playerWallet = FindObjectOfType<Wallet>();
        blinkingText = FindObjectOfType<BlinkingText>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //Check if player has enough coins to unlock the goal
        if(playerWallet.GetCoins() >= target)
        {
            isUnlocked = true;
            spriteRenderer.color = unlockColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Complete the level if the player has enough coins
        if (other.GetComponent<Wallet>() == playerWallet)
        {
            if(isUnlocked) {
                if(isDone == false)
                {
                    isDone = true;
                    playerController.StopPlayer();
                    MakePlayerJump();
                    gameSession = FindObjectOfType<GameSession>();
                    gameSession.AddTwoLives();
                    blinkingText.StartBlinkingText();
                    
                    LevelManager.Instance.LoadNextLevel();
                }
                
            }
        }
    }

    void MakePlayerJump()
    {
        Rigidbody2D rb = playerController.gameObject.GetComponent<Rigidbody2D>();


        rb.velocity += jumpForce;
    }

    public int GetCoinTarget()
    {
        return target;
    }

    
}
