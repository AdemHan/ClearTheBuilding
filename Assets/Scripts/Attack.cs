using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private int maxAmmoCount = 5;
    private int ammoCount = 0;
    public int GetAmmo { get { return ammoCount; } 
        set { ammoCount = value; 
            if (ammoCount > maxAmmoCount) ammoCount = maxAmmoCount; } }


    [SerializeField] private float fireRate = 0.5f;

    private float currenFireRate = 0f;
    void Start()
    {
        ammoCount = maxAmmoCount;
    }


    void Update()
    {
        if (currenFireRate > 0f)
        {
            currenFireRate -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (currenFireRate <= 0 && ammoCount > 0)
            {
                Fire();
            }
            
        }
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
        ammoCount--;
        currenFireRate = fireRate;
        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f,0f,targetRotation));
        bulletClone.GetComponent<Bullet>().owner = gameObject;
    }
}
