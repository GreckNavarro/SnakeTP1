using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance { get; private set; }
    [SerializeField] private int actualScore;
    [SerializeField] private int highScore;
    [SerializeField] private UI_Manager _UImanager;


    private void Start()
    {
        highScore = GetHighScore();
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }


    }

  

    public void IncrementScore(int a)
    {
        actualScore += a;
        _UImanager.UpdateText();

    }

    public int GetScore()
    {
        return actualScore;
    }

    public void CompareHighScore()
    {
        if(actualScore > highScore)
        {
            SaveHighScore(actualScore);
        }
    }


    private void SaveHighScore(int newscore)
    {
        PlayerPrefs.SetInt("HighScore", newscore);
        PlayerPrefs.Save();
    }

    public int GetHighScore()
    {
        int highscore = PlayerPrefs.GetInt("HighScore");
        return highscore;
    }

    public void ResetScore()
    {
        Time.timeScale = 1;
        actualScore = 0;
        SceneManager.LoadScene(0);

    }

    public void EndGame()
    {
        _UImanager.EndGame(actualScore, GetHighScore());
        Time.timeScale = 0;

    }
}
