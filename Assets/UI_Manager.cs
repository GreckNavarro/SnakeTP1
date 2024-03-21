using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject panelderrota;
    [SerializeField] private Text actualScoreText;
    [SerializeField] private Text highScoreText;


    [SerializeField] private Text CurrentScoreGame;
    [SerializeField] private Text HighScoreGame;

    private void Start()
    {
        HighScoreGame.text = ScoreManager.Instance.GetHighScore().ToString();
    }
    public void UpdateText()
    {
        CurrentScoreGame.text = ScoreManager.Instance.GetScore().ToString();
    }
    public void EndGame(int currentScore, int highScore)
    {
        actualScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();
        panelderrota.SetActive(true);
    }
}
