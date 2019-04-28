using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("HIT");
            FindObjectOfType<ChallengeFour>().PickupCollected();

            
            Destroy(this.gameObject);
        }
    }
}
