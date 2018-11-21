using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestroyObj")
        {
            DestroySequence();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Rebound")
        {
            float magnitude = 400;
            // calculate force vector
            if (collision.contacts.Length > 0)
            {
                Vector3 force = collision.contacts[0].normal;
                // normalize force vector to get direction only and trim magnitude
                force.Normalize();
                this.GetComponent<Rigidbody>().AddForce(force * magnitude);
            }



        }
    }

    private void DestroySequence()
    {   
        //Create particle effect
        Destroy(this.gameObject);
    }
}
