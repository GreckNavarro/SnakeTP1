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
    }

    public void CompareHighScore()
    {
        if(actualScore > highScore)
        {
            highScore = actualScore;
        }
    }

    public void ResetScore()
    {
        Time.timeScale = 1;
        actualScore = 0;
        SceneManager.LoadScene(0);

    }

    public void EndGame()
    {
        Time.timeScale = 0;
        _UImanager.EndGame(actualScore, highScore);

    }
}
