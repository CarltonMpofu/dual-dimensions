using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    public void LoadStartScene()
    {
        Destroy(gameSession.gameObject);
        LevelManager.Instance.LoadStartScene();
    }
}
