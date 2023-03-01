using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        print(transform.eulerAngles.y);
    }

    private void Fire()
    {
        float difference = 180f - transform.eulerAngles.y;
        float targetRotation = -90f;

        if (difference < 90f)
        {
            targetRotation = -90;
        }
        else if (difference >= 90f)
        {
            targetRotation = 90f;
        }
        Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f,0f,targetRotation));
    }
}
