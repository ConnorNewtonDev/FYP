using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : Interactable
{
    private Rigidbody rb3d;
    public override void Start()
    {
        rb3d = this.GetComponent<Rigidbody>();
    }

    public override void Action()
    {
       Vector3 pTemp = this.transform.position - FindObjectOfType<Player>().transform.position;
       
       Quaternion relavtiveRot = Quaternion.LookRotation(pTemp, Vector3.up);

        float angle = Quaternion.Angle(transform.rotation, relavtiveRot);
        rb3d.constraints = RigidbodyConstraints.None;

        if(angle < 45)
        {          
            rb3d.constraints = RigidbodyConstraints.FreezePositionX;
        }
        else if(angle >= 45 && angle < 135)
        {
            rb3d.constraints = RigidbodyConstraints.FreezePositionZ;
        }
        else if(angle >= 135 && angle <= 180)
        {
            rb3d.constraints = RigidbodyConstraints.FreezePositionX;
        }

        rb3d.constraints =  rb3d.constraints | RigidbodyConstraints.FreezeRotation;
    }

    public override void EndAction()
    {
        rb3d.constraints = RigidbodyConstraints.FreezeAll;
    }

}
