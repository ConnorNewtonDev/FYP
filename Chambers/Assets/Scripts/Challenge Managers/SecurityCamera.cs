using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{

    public float scanDist;
    public float scanSpeed;

    private bool moveRight = true;
    private Quaternion targetRot;
    private Quaternion initRot;
    // Start is called before the first frame update
    void Start()
    {
        initRot = this.transform.rotation;
        targetRot = this.transform.rotation;
        targetRot.y += scanDist / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Scan();

        
    }

    private void Scan()
    {
        if (Quaternion.Angle(initRot, transform.rotation) >= Quaternion.Angle(initRot, targetRot))
        {
            if (moveRight)
                targetRot.y -= scanDist;
            else
                targetRot.y += scanDist;

            moveRight = !moveRight;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.time * scanSpeed);
    }
}
