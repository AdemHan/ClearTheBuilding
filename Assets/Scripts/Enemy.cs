using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float shootRange = 10f;  //ates mesafesi
    [SerializeField] private float reloadTime = 5f;
    [SerializeField] private LayerMask shootLayer;
    private Transform aimTransform;
                                    
    // Fiziksel islemlerde tag yerine layer kullanmak daha mantýklý

    private bool canMoveRight = false;
    private bool isReloaded = false;
    private Attack attack;

    private void Awake()
    {
        attack = GetComponent<Attack>();
        aimTransform = attack.GetFireTransform;
    }

    

    
    void Update()
    {
        EnemyAttack();

        CheckCanMoveRight();

        MoveTowards();

        Aim();
    }

    private void Reload()
    {
        attack.GetAmmo = attack.GetClipSize;
        isReloaded = false;
        print("Reloaded");
    }

    //Invoke veriler X surede kaybolurlar. Metodun adi string seklinde yazilir.
    private void EnemyAttack()
    {
        if (attack.GetAmmo <= 0 && isReloaded == false)   
        {
            Invoke("Reload", reloadTime);
            isReloaded = true;
        }

        if (attack.GetCurrentFireRate <= 0f && attack.GetAmmo > 0 && Aim())
        {
            attack.Fire();
        }
    }

    private void MoveTowards()
    {
        if (Aim() && attack.GetAmmo > 0)
        {
            return;
        }
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

    private bool Aim()
    {
        bool hit = Physics.Raycast(aimTransform.position, transform.forward, shootRange, shootLayer);
        Debug.DrawLine(aimTransform.position, transform.forward * shootRange, Color.blue);
        return hit;
    }

    private void LookAtTheTarget(Vector3 newTarget)
    {
        Vector3 newLookPosition = new Vector3(newTarget.x, transform.position.y, newTarget.z);
        Quaternion targetRotation = Quaternion.LookRotation(newLookPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
//newLookPosition - transform.position