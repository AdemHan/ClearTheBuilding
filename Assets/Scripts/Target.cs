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
        if (other.gameObject.GetComponent<Bullet>() == true )
        {
            Destroy(other.gameObject);
            currentHealth--;
            if (currentHealth == 0)
            {
                Die();
            }
            
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
