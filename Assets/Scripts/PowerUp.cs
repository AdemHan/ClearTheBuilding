using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Settings")]
    public bool healtPowerUp = false;
    public int healtAmount = 1;

    [Header("Ammo Settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 5;

    [Header("Transform Settings")]
    [SerializeField] private float turnSpeed = -1f;
    void Start()
    {
        if (healtPowerUp == true && ammoPowerUp == true)
        {
            healtPowerUp = false;
            ammoPowerUp = false;
        }
        else if (healtPowerUp == true)
        {
            ammoPowerUp = false;
        }
        else if (ammoPowerUp == true)
        {
            healtPowerUp = false;
        }
    }


    void Update()
    {
        transform.Rotate(0f, turnSpeed, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (healtPowerUp == true)
            {
                other.gameObject.GetComponent<Target>().GetHealth += healtAmount;
            }
            else if (ammoPowerUp)
            {
                other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
            }
            Destroy(gameObject);
        }
        
    }
}
