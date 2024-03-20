using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            _gameManager.CreateFood();
            Debug.Log("Se creo en tu cuerpo");
        }
    }
    
}
