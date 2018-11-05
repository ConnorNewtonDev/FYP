using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Transform target;
    private Vector3 offset = new Vector3(1f, -7, 6);
    private Vector3 defaultRot = new Vector3(50, 15, 0);
    private float dampening = 15f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        this.transform.position = Vector3.Lerp(this.transform.position, (target.position - offset), dampening);
    }

    //Target the camera onto an object.
    public void TargetObject(GameObject _target)
    {
        target = _target.transform;
        this.transform.rotation = Quaternion.Euler(defaultRot);
    }

}
