using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Variables
    [SerializeField]
    private Transform target;
    private Vector3 offset = new Vector3(1f, -7, 6);
    [SerializeField]
    private float dampening;
    // Start is called before the first frame update
    void Start()
    {
        TargetObject(GameObject.Find("Player"));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, (target.position - offset), dampening);
    }

    //Target the camera onto an object.
    public void TargetObject(GameObject _target)
    {
        target = _target.transform;
    }

}
