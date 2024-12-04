using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControlScript : MonoBehaviour
{
    Rigidbody rb;
    float jumpforce = 5;
    float explosionRadius = 5;
    float explosionStrength = 800;


    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpforce*Vector3.up, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        VictimScript victimScript = collision.gameObject.GetComponent<VictimScript>();

        Collider[] allVictims = Physics.OverlapSphere(transform.position + Vector3.down, explosionRadius);

        foreach (Collider collider in allVictims)
        {
            VictimScript newVictim = collider.gameObject.GetComponent<VictimScript>();

            if (newVictim != null)
            {
                newVictim.Bump(explosionStrength, transform.position + Vector3.down, explosionRadius);
            }
        }

        if (victimScript != null) 
        {
            victimScript.Bump(explosionStrength, transform.position + Vector3.down, explosionRadius);
           
        }

        //if (collision.gameObject.name == "Victim")
        //{ 
        //    Rigidbody victimRB = collision.gameObject.GetComponent<Rigidbody>();
        //    if (victimRB != null)
        //    {
        //        print("hit");
        //        victimRB.AddExplosionForce(1000, transform.position + Vector3.down, 5);
        //    }

        //}
    }


}
