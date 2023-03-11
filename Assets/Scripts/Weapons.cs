using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private Attack attack;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float fireRate;
    [SerializeField] private int clipSize;
    private int currentAmmoCount;

    public int GetCurrentWeaponAmmoCount
    {
        get
        {
            return currentAmmoCount;
        }
        set
        {
            currentAmmoCount = value;
        }
    }

    private void Awake()
    {
        currentAmmoCount = clipSize;

    }


    private void OnEnable()
    {
        if (attack != null)
        {
            attack.GetFireTransform = fireTransform;
            attack.GetFireRate = fireRate;
            attack.GetClipSize = clipSize;
            attack.GetAmmo = currentAmmoCount;
        }
    }
}
