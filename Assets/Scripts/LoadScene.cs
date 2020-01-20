using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {


    public void Sceneloader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void GameWon()
    {
        SceneManager.LoadScene("GameWon");
    }

    public void GameLost()
    {
        SceneManager.LoadScene("GameLost");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }
}
