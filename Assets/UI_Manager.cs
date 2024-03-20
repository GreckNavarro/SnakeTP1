using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject panelderrota;
    [SerializeField] private Text actualScoreText;
    [SerializeField] private Text highScoreText;



    public void UpdateText()
    {

    }
    public void EndGame(int currentScore, int highScore)
    {
        actualScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();
        panelderrota.SetActive(true);
    }
}
