using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFinish : MonoBehaviour
{
    public ChallengeBase challenge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            for (int i = 0; i < challenge.transform.childCount - 1; i++)
            {
                Destroy(challenge.spawnParent.GetChild(i).gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
