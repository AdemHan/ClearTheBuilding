using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject ammo;
    [SerializeField] private bool isPlayer = false;

    private int ammoCount = 0;
    private Transform fireTransform;
    private float fireRate = 0.5f;
    private int maxAmmoCount = 5;

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
        set
        {
            maxAmmoCount = value;
        }
    }

    public float GetFireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }

    public Transform GetFireTransform
    {
        get
        {
            return fireTransform;
        }
        set
        {
            fireTransform = value;
        }
    }
    void Start()
    {
        //ammoCount = maxAmmoCount;
    }


    void Update()
    {
        if (currenFireRate > 0f)
        {
            currenFireRate -= Time.deltaTime;
        }
        PlayerInput();

    }

    private void PlayerInput()
    {
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currenFireRate <= 0 && ammoCount > 0)
                {
                    Fire();
                }
            }
            switch (Input.inputString)
            {
                case "1":
                    weapons[1].gameObject.GetComponent<Weapons>().GetCurrentWeaponAmmoCount = ammoCount;
                    weapons[0].gameObject.SetActive(true);
                    weapons[1].gameObject.SetActive(false);
                    break;
                case "2":
                    weapons[0].gameObject.GetComponent<Weapons>().GetCurrentWeaponAmmoCount = ammoCount;
                    weapons[0].gameObject.SetActive(false);
                    weapons[1].gameObject.SetActive(true);
                    break;
                default:
                    print("this is not valid key");
                    break;
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
        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
        bulletClone.GetComponent<Bullet>().owner = gameObject;
    }
}
