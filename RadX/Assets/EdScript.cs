using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdScript : MonoBehaviour
{
    public GameObject giftCloneTemplate;
    float turningSpeed = 90;
    float speed;
    float walkingSpeed = 1;
    float runningMultiplier = 3;
    Animator edanim;


    // Start is called before the first frame update
    void Start()
    {
        edanim = GetComponent<Animator>();
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed = 0;
        edanim.SetBool("IsWalking", false);
        edanim.SetBool("IsRunning", false);
        edanim.SetBool("IsWalkingBack", false);

        if (Input.GetKey(KeyCode.W))
        {
            speed = walkingSpeed;
         
            edanim.SetBool("IsWalking", true);
        }
        if(Input.GetKey(KeyCode.S))
        {
            speed = -walkingSpeed;
            edanim.SetBool("IsWalkingBack", true);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= runningMultiplier;
            edanim.SetBool("IsRunning", true);
        }
            if (Input.GetKey(KeyCode.A))
        {
            // Roll Left
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // Pitch Up
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(giftCloneTemplate,transform.position,transform.rotation);
        }
        transform.position += speed * transform.forward * Time.deltaTime;
    }

}
