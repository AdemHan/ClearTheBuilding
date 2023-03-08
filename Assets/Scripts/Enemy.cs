using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;

    private bool canMoveRight = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        ChecjCanMoveRight();

        MoveTowards();
    }
    
    private void MoveTowards()
    {
        if (!canMoveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[0].position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[1].position, speed * Time.deltaTime);

        }
    }

    private void ChecjCanMoveRight()
    {
        if (Vector3.Distance(transform.position, movePoints[0].position) <= 0 )
        {
            canMoveRight = true;
            print("Move Right");
        }
        else if (Vector3.Distance(transform.position, movePoints[1].position) <= 0)
        {
            canMoveRight = false;
            print("Move Left");
        }
    }
}
