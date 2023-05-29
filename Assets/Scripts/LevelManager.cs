using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singleton Stuff
    static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.LogErrorFormat("[Singleton] Trying to instantiate a second instance of singleton class {0} from {1}", GetType().Name, this.gameObject.name);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    #endregion

    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void ReloadLevel()
    {
        //Debug.Log("Doo");
        player.isActive = false;
        // GameSession gameSession = FindObjectOfType<GameSession>();
        // gameSession.ProcessPlayerDeath();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        //player.isActive = false;
        yield return new WaitForSecondsRealtime(1f);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }

    public void LoadGameOverScene()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("GameOverScene");
    }
}
