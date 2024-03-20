using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField] private GameObject FoodPrefab;
    [SerializeField] private int maxScore;
    private bool active;
    public  Vector2 posicioninial;
    [SerializeField] private Vector2[] limites;

    private void Start()
    {
        posicioninial = FoodPrefab.transform.position;
        Debug.Log(posicioninial);
    }
    public void CreateFood()
    {

        Vector2 RandomPosition = new Vector2(posicioninial.x + 0.5f * Random.Range(1, 18), posicioninial.y + 0.5f * Random.Range(1, 17));

        Debug.Log(RandomPosition);

        FoodPrefab.transform.position = RandomPosition;


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
