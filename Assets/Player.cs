using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  

    private Vector2 direction;
    [SerializeField] private float velocity = 0.3f;
    private float distance = 0.5f;
    public List<Transform> Tail = new List<Transform>();
    Vector3 lastposition;
    public GameObject tailPrefab;



    [SerializeField] private GameManager _GManager;

    private void Start()
    {

        InvokeRepeating("Movement", velocity, velocity);
        direction = Vector2.right;
    }

    void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (direction != Vector2.down)
                direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (direction != Vector2.up)
                direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (direction != Vector2.left)
                direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (direction != Vector2.right)
                direction = Vector2.left;
        }
    }


    void Movement()
    {
        lastposition = transform.position;

        Vector3 nextDirec = Vector2.zero;
        if(direction == Vector2.right)
            nextDirec = Vector2.right;
        if (direction == Vector2.left)
            nextDirec = Vector2.left;
        if (direction == Vector2.up)
            nextDirec = Vector2.up;
        if (direction == Vector2.down)
            nextDirec = Vector2.down;

        nextDirec *= distance;
        transform.position += nextDirec;

        MoveTail();
    }

    void MoveTail()
    {
        for(int i = 0; i < Tail.Count; i++)
        {
            Vector3 temp = Tail[i].position;
            Tail[i].position = lastposition;
            lastposition = temp;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Limite")
        {
            _GManager.SetActive(false);
        }
        else if(collision.gameObject.tag == "Body")
        {
            _GManager.SetActive(false);
        }
        else if(collision.gameObject.tag == "Food")
        {
           Tail.Add(Instantiate(tailPrefab, Tail[Tail.Count - 1].position, Quaternion.identity).transform);
            _GManager.CreateFood();
            ScoreManager.Instance.IncrementScore(1);
        }
    }




    private void Update()
    {
        CheckMovement();

    }
}
