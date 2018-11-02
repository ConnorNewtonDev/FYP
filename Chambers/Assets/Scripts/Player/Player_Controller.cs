using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //References
    private Animator anim;
    private Rigidbody rb3d;
    //Variables
    private Vector3 moveDir;
    private float deadzone = 0.2f;
    private float lookSpeed = 8f;
    private float speed = 3;
    

    void Start()
    {
        //Get Components
        anim = GetComponent<Animator>();
        rb3d = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb3d.velocity = moveDir * speed;
        Vector3 localVelocity = transform.InverseTransformDirection(rb3d.velocity);
        Vector3.Normalize(localVelocity);
        anim.SetFloat("Forward", localVelocity.z);
        anim.SetFloat("Turn", localVelocity.x);
    }

    private void Look(Vector3 moveDir)
    {
            Vector3 _dir = (moveDir - this.transform.position).normalized;
            Quaternion _lookDir = Quaternion.LookRotation(_dir);
            transform.rotation = _lookDir;
    }

    private void HandleInput()
    {
        Vector3 joystickInput = new Vector3(Input.GetAxis("HorizontalL"), 0, Input.GetAxis("VerticalL") * -1);

        if (joystickInput.magnitude < deadzone)
        {
            joystickInput = Vector2.zero;
            moveDir = Vector3.zero;
        }
        else
        {
            moveDir = joystickInput.normalized * ((joystickInput.magnitude - deadzone) / (1 - deadzone));
            Vector3 rotDir = new Vector3(this.transform.eulerAngles.x, Mathf.Atan2(joystickInput.x, joystickInput.z) * Mathf.Rad2Deg, this.transform.eulerAngles.z);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotDir), lookSpeed * Time.deltaTime);
        }


        //Look
     

    }
}
