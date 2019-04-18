using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //References
    private Animator anim;
    private Rigidbody rb3d;
    private Camera_Controller camControl;
    private bool hasCamControl = true;
    //Variables
    //Camera World View
    private Vector3 forward;
    private Vector3 right;
    //Controls
    public bool inControl;
    private float deadzone = 0.2f;
    private float lookSpeed = 8f;
    private float speed = 3.25f;
    private Vector3 moveDir;


    void Start()
    {
        //Get Components
        anim = GetComponent<Animator>();
        rb3d = GetComponent<Rigidbody>();

        //Get and Setup Camera to Follow
        hasCamControl = SetupCamera();
        inControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

    }

    void FixedUpdate()
    {
        if (inControl)
            Move();
        else
        {
            rb3d.velocity = Vector3.zero;
            anim.SetFloat("Forward", 0);
            anim.SetFloat("Turn", 0);
        }

    }

    private bool SetupCamera()
    {
        camControl = FindObjectOfType<Camera_Controller>();
        //Escape if no controller in scene (static cam)
        if(camControl == null)
            return false;

        camControl.TargetObject(this.gameObject);

        //Set the Vector forwards to be that of the camera
        forward = camControl.transform.forward;
        right = camControl.transform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        return true;

    }

    private void Move()
    {
        rb3d.velocity = moveDir * speed;
        //Get the velocity of the player relative to the direction facing
        Vector3 localVelocity = transform.InverseTransformDirection(rb3d.velocity);
        Vector3.Normalize(localVelocity);
        //Apply values for blend tree
        anim.SetFloat("Forward", localVelocity.z);
        anim.SetFloat("Turn", localVelocity.x);
    }

    private void Look(Vector3 joystickInput)
    {
        Vector3 rotDir = new Vector3(this.transform.eulerAngles.x, Mathf.Atan2(joystickInput.x, joystickInput.z) * Mathf.Rad2Deg, this.transform.eulerAngles.z);
        this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotDir), lookSpeed * Time.deltaTime);
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
            moveDir = joystickInput.normalized/* * ((joystickInput.magnitude - deadzone) / (1 - deadzone))*/;
            Look(joystickInput);
            
        }    

    }

    public void DeathScreen()
    {
        GameObject panel = camControl.deathPanel;
        camControl.StartCoroutine(camControl.FadeUI(panel, 0, 1));
    }
}
