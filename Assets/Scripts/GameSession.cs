using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 5;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

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
        scoreText.text = score.ToString(); 
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
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
        //livesText.text = playerLives.ToString();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LevelManager.Instance.ReloadLevel();
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        LevelManager.Instance.LoadGameOverScene();
    }

    public int GetScore()
    {
        return score;
    }

    public void AddTwoLives()
    {
        Debug.Log("Added");
        Debug.Log(playerLives);
        playerLives += 2;
        Debug.Log(playerLives);
        livesText.text = playerLives.ToString();
    }
}
