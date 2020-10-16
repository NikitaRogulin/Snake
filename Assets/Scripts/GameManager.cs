using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

[Serializable]
public class UnityEventString : UnityEvent<string>
{

}

public class GameManager : MonoBehaviour
{
    //СИНГЛТОН
    //private static GameManager gameManager;

    //public static GameManager GameManagerInstance
    //{
    //    get
    //    {
    //        if (gameManager == null)
    //            gameManager = new GameManager();
    //        return gameManager;
    //    }
    //}

    int score;

    [SerializeField]
    GameObject deathScreen;

    public UnityEventString ScoreChanged;

    public void AddScore()
    {
        score += 10;
        ScoreChanged.Invoke("Score: " + score.ToString());
    }

    public void GameOver()
    {
        deathScreen.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
}
