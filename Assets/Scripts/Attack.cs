using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private int maxAmmoCount = 5;
    [SerializeField] private bool isPlayer = false;
    private int ammoCount = 0;



    [SerializeField] private float fireRate = 0.5f;

    private float currenFireRate = 0f;
    public float GetCurrentFireRate
    {
        get
        {
            return currenFireRate;
        }
        set
        {
            currenFireRate = value;
        }
    }
    public int GetAmmo
    {
        get { return ammoCount; }
        set
        {
            ammoCount = value;
            if (ammoCount > maxAmmoCount) ammoCount = maxAmmoCount;
        }
    }

    public int GetClipSize
    {
        get
        {
            return maxAmmoCount;
        }
    }
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
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currenFireRate <= 0 && ammoCount > 0)
                {
                    Fire();
                }

            }
        }
        
    }

    public void Fire()
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
