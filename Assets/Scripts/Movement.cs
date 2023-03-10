using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private Transform[] rayStartPoint;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        TakeInput();
        print(OnGroundCheck());
    }

    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGroundCheck() == true)   //GetKeyDown-------> Sadece bir kez alg?lar
        {                                      //GetKey-----------> Bas?l? tutuldu?u s?re boyunca alg?lar

            rigidbody.velocity = new Vector3(rigidbody.velocity.x, Mathf.Clamp((jumpPower * 100) * Time.deltaTime, 0f, 15f), 0f);                                   

        }



        if (Input.GetKey(KeyCode.A))            // if ?al???yorsa else if ?al??maz, else if ?al???yorsa if ?al??maz
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

    private bool OnGroundCheck()
    {
        bool hit = false;

        for (int i = 0; i < rayStartPoint.Length; i++)
        {
            hit = Physics.Raycast(rayStartPoint[i].position, -rayStartPoint[i].transform.up, 0.25f);
            Debug.DrawRay(rayStartPoint[i].position, -rayStartPoint[i].transform.up * 0.25f, Color.red);
        }

        
        if (hit == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
