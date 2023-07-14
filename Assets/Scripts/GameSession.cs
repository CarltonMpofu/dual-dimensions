using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 5;
    [SerializeField] TextMeshProUGUI livesText;
    

    private void Awake() {
        
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length; 

        if(numberOfGameSessions > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);       
        }
    }

    private void Update() {
        
    }

    private void Start() 
    {
        //Debug.Log(playerLives);
        livesText.text = playerLives.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives -= 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelManager.Instance.ReloadLevel();
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        LevelManager.Instance.LoadGameOverScene();
    }

    public void AddTwoLives()
    {
        // Debug.Log(playerLives);
        playerLives += 2;
        // Debug.Log(playerLives);
        livesText.text = playerLives.ToString();
    }
}
