using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 13f;
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
        if (Input.GetKeyDown(KeyCode.Space))   //GetKeyDown-------> Sadece bir kez alg�lar
        {                                      //GetKey-----------> Bas�l� tutuldu�u s�re boyunca alg�lar

            rigidbody.velocity = new Vector3(rigidbody.velocity.x, (jumpPower * 100) * Time.deltaTime, 0f);                                   
            print("jumping");
        }
        else
        {
            print("Not Jumping");
        }


        if (Input.GetKey(KeyCode.A))            // if �al���yorsa else if �al��maz, else if �al���yorsa if �al��maz
        {
            rigidbody.velocity = new Vector3((speed * 100) * Time.deltaTime, rigidbody.velocity.y, 0f);
            print("Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3((-speed * 100) * Time.deltaTime, rigidbody.velocity.y, 0f);
            print("R�ght");
        }
        else
        {
            print("Not press A or D");
        }
    }
}
