using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdScript : MonoBehaviour
{
    public GameObject giftCloneTemplate;
    bool hasTurned = false;
    float turningSpeed = 90;
    float speed;
    float walkingSpeed = 1;
    float runningMultiplier = 3;
    Animator edanim;
    Transform camera;
    float giftHeight = 0.5f, giftForward = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
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
        edanim.SetBool("IsTurning", false);

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
            if (!hasTurned)
            {
                camera.parent = null;
                transform.Rotate(Vector3.up, -90);
                hasTurned = true;
            }
            
            speed = walkingSpeed;
            edanim.SetBool("IsWalking", true);
            //transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
            camera.parent = transform;
            //edanim.SetBool("IsTurning", true) ;

        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!hasTurned)
            {
                camera.parent = null;
                transform.Rotate(Vector3.up, 90);
                hasTurned = true;
            }

            speed = walkingSpeed;
            edanim.SetBool("IsWalking", true);
            //transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
            camera.parent = transform;
            //edanim.SetBool("IsTurning", true) ;


            //camera.parent = null;
            //transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
            //camera.parent = transform;
            //edanim.SetBool("IsTurning", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject newGiftGO =  Instantiate(giftCloneTemplate,transform.position + giftForward * transform.forward +giftHeight *transform.up,transform.rotation);
           GiftProjectileScript newGift = newGiftGO.GetComponent<GiftProjectileScript>();
            newGift.launchMe(transform.forward);
        }
        transform.position += speed * transform.forward * Time.deltaTime;


        hasTurned = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
        
    }

}
