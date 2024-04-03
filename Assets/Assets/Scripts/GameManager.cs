using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public bool isGameOver = false;
    public Text ScoreText;
    public Text CoinText;
    public GameObject gameOverUI;

    private int Score = 0;
    private int CoinScore = 0;

    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int Score)
    {
        if (!isGameOver)
        {
            this.Score += Score;
            ScoreText.text = "Score : " + this.Score;
        }
    }

    public void AddCoinScore(int CoinScore)
    {
        if (!isGameOver)
        {
            this.CoinScore += CoinScore;
            CoinText.text = "CoinScore : " + this.CoinScore;
        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }
}
