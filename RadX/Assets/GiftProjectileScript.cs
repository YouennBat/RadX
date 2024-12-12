using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftProjectileScript : MonoBehaviour
{
    Rigidbody rb;

    float force = 20f;

    float jumpforce = 10;
    float explosionRadius = 1;
    float explosionStrength = 1000;

    internal void launchMe(Vector3 dir)
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        rb.AddForce(force*dir, ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
}
