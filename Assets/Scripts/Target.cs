using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();

        if (bullet)
        {
            if (bullet && bullet.owner != gameObject)
            {
                currentHealth--;

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
        Destroy(gameObject);
    }
}
