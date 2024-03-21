using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField] private GameObject FoodPrefab;
    [SerializeField] private int maxScore;
    private bool active;
    Vector2 posicioninial;
    [SerializeField] private AudioClip eat;


    private void Start()
    {
        posicioninial = FoodPrefab.transform.position;

    }
    public void CreateFood()
    {

        Vector2 RandomPosition = new Vector2(posicioninial.x + 0.5f * Random.Range(1, 18), posicioninial.y + 0.5f * Random.Range(1, 17));
        AudioManager.Instance.PlaySound(eat);

        FoodPrefab.transform.position = RandomPosition;

        if(maxScore <= ScoreManager.Instance.GetScore())
        {
            ScoreManager.Instance.EndGame();
        }


    }

    public void SetActive(bool vida)
    {
        active = vida;
        if(active == false)
        {
            ScoreManager.Instance.CompareHighScore();
            ScoreManager.Instance.EndGame();
        }

    }

    
}
