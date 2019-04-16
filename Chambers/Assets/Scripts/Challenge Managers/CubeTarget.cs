using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactable")
        {

            CheckPosition(other.transform.position);
            CheckPosition(other.transform.position, 5.0f);
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
