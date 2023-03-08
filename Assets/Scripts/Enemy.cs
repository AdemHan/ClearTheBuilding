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
        CheckCanMoveRight();

        MoveTowards();
    }
    
    private void MoveTowards()
    {
        if (!canMoveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[0].position.x, transform.position.y, movePoints[0].position.z), speed * Time.deltaTime);
            LookAtTheTarget(movePoints[0].position);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[1].position.x, transform.position.y, movePoints[0].position.z), speed * Time.deltaTime);
            LookAtTheTarget(movePoints[1].position);
        }
    }

    private void CheckCanMoveRight()
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

    private void LookAtTheTarget(Vector3 newTarget)
    {
        Vector3 newLookPosition = new Vector3(newTarget.x, transform.position.y, newTarget.z);
        Quaternion targetRotation = Quaternion.LookRotation(newLookPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
//newLookPosition - transform.position