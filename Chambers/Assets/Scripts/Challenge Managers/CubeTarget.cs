using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isFilled = false;
    void Start()
    {
        
    }

    public bool GetFilledState() {return isFilled;}
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactable")
        {
            if(CheckPosition(other.transform.position))
            {
                isFilled = true;
                other.tag = "Untagged";                
                FindObjectOfType<ChallengeThree>().OpenDoor();
            }
        }
    }

    private bool CheckPosition(Vector3 position, float variance = 0.5f)
    {
        if(Vector3.Distance(this.transform.position, position) <= variance)
            return true;
        else 
            return false;
    }

    private IEnumerator ReceiveCube()
    {


        yield return null;
    }
}
