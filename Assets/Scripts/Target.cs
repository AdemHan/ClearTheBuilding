using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject deadFx;


    private int currentHealth;
    public int GetHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
    private void Awake()
    {
        currentHealth = maxHealth;

    }
    

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();

        if (bullet)
        {
            if (bullet && bullet.owner != gameObject)
            {
                currentHealth--;

                if (hitFx != null)
                {
                    Instantiate(hitFx, transform.position, Quaternion.identity);
                }

                if (currentHealth == 0)
                {
                    Die();
                }

                
                Destroy(other.gameObject);
            }
        }
    }

    private void Die()
    {
        if (deadFx != null)
        {
            Instantiate(deadFx, transform.position, Quaternion.identity);

        }
        Destroy(gameObject);
    }
}
