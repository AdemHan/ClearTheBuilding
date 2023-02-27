using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float turnSpeed = 15f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        TakeInput();
    }

    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))   //GetKeyDown-------> Sadece bir kez algýlar
        {                                      //GetKey-----------> Basýlý tutulduðu süre boyunca algýlar

            rigidbody.velocity = new Vector3(rigidbody.velocity.x, Mathf.Clamp((jumpPower * 100) * Time.deltaTime, 0f, 15f), 0f);                                   

        }



        if (Input.GetKey(KeyCode.A))            // if çalýþýyorsa else if çalýþmaz, else if çalýþýyorsa if çalýþmaz
        {
            rigidbody.velocity = new Vector3(Mathf.Clamp((speed * 100) * Time.deltaTime, 0f, 15f), rigidbody.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -180f, 0f), turnSpeed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(Mathf.Clamp((-speed * 100) * Time.deltaTime, -15f, 0f), rigidbody.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), turnSpeed * Time.deltaTime);
        }
        else
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 0f);
        }
    }
}
