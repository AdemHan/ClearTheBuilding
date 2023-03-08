using System;
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
    [SerializeField] Vector3 turnVector = Vector3.zero;

    [Header("Scale Settings")]
    [SerializeField] private float period = 2f;
    [SerializeField] Vector3 scaleVector;
    [SerializeField] private float scaleFactor;
    private Vector3 startScale;
    void Start()
    {
        startScale = transform.localScale;

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
        transform.Rotate(turnVector);
        SinusWawe();
    }

    private void SinusWawe()
    {
        if (period <= 0f)
        {
            period = 0.1f;
        }
        float cyles = Time.timeSinceLevelLoad / period;

        const float piX2 = Mathf.PI * 2;

        float sinusWawe = Mathf.Sin(cyles * piX2);

        scaleFactor = sinusWawe / 2 + 0.5f; //-1 ve 1 aralýðýnda olmasýndansa 0 ve 1 aralýðýnda olmasýný saðladýk.

        Vector3 offset = scaleFactor * scaleVector;

        transform.localScale = startScale + offset;
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
