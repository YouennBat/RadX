using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    float turningSpeed = 90;
    float thrustValue = 2;
    // float gravity = 2;
    Rigidbody rb;
    Vector3 velocity, acceleration;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //acceleration = Vector3.zero;
        // acceleration += gravity * Vector3.down;

        if (Input.GetKey(KeyCode.W))
        {
            //  transform.position += transform.up * Time.deltaTime;
            // acceleration += thrustValue * transform.up;
            rb.AddForce(thrustValue * transform.up);

        }

        if (Input.GetKey(KeyCode.A))
        {
            // Rotate Left
            transform.Rotate(Vector3.forward, turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Rotate Right
            transform.Rotate(Vector3.back, turningSpeed * Time.deltaTime);
        }

        //Roll Using Mouse 
        //transform.Rotate(Vector3.up,
           // Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime);

       // transform.Rotate(Vector3.right,
           // Input.GetAxis("Vertical") * turningSpeed * Time.deltaTime);

        //velocity += acceleration * Time.deltaTime;
        // transform.position += velocity * Time.deltaTime;  
    }
}
