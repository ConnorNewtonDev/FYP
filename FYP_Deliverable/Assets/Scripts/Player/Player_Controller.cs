using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //--- Public ---//
    public bool inControl;
    public float speed;
    public float lookSpeed = 2f;
    //--- Private ---//
    [SerializeField]
    private bool wallRunning = false;
    private bool wallOnRight = false;
    private bool grounded;
    private float deadzone = 0.35f;
    private float pitch;
    

    private RaycastHit wallHit;
    private Vector3 moveDirection;
    private GameObject wall = null;
    private Rigidbody rb3d;
    private Camera pCamera;


    void Start()
    {
        inControl = true;
        rb3d = GetComponent<Rigidbody>();
        pCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))     //Change to GetButtonDown
            Jump();
    }

    void FixedUpdate()
    {
        if(inControl)
        {

            CheckForGround();
            if (wallRunning)
                WallrunMove();
            else
                Move();

            Look();
        }

    }

    private void CheckForGround()
    {
        //Check Right
        Debug.DrawRay(transform.position, transform.up * -1, Color.cyan, 5f, false);
        if (Physics.SphereCast(transform.position, 0.5f, transform.up * -1, out wallHit, 2))
        {
            if (wallHit.distance < 1)
            {
                grounded = true;
                wallRunning = false;
            }
        }
    }

    private bool CheckForWall()
    {

        //Check Right
        if (Physics.Raycast(transform.position, transform.right, out wallHit, 2))
        {
            if (wallHit.distance < 2)
            {
                wallOnRight = true;
                return true;
            }
        }
        //Check Left
        if (Physics.Raycast(transform.position, transform.right * -1,out wallHit, 2))
        {
            if (wallHit.distance < 2)
            {
                wallOnRight = false;
                return true;
            }
        }        
        return false;
    }

    private void Move()
    {
        //Check for input against deadzone
        Vector3 joystickInput = new Vector3(Input.GetAxis("HorizontalL"), 0, Input.GetAxis("VerticalL") * -1);

        if (joystickInput.magnitude < deadzone)
        {
            joystickInput = Vector2.zero;
            rb3d.velocity = new Vector3(0, 0, 0);
        }
        else
            joystickInput = joystickInput.normalized * ((joystickInput.magnitude - deadzone) / (1 - deadzone));
        //Move player
        //Vector3 moveDir = transform(joystickInput);
        //rb3d.AddRelativeForce(joystickInput * speed);
        Vector3 moveDir = transform.TransformDirection(joystickInput);
        rb3d.velocity = moveDir * speed;


    }

    private void WallrunMove()
    {
        if (CheckForWall() == false)
        {
            wallRunning = false;
        }
        //Check for input against deadzone
        Vector3 joystickInput = new Vector3(Input.GetAxis("HorizontalL"), 0, Input.GetAxis("VerticalL") * -1);

         joystickInput = joystickInput.normalized * ((joystickInput.magnitude - deadzone) / (1 - deadzone));
        //Move player along wall
        moveDirection = Vector3.Cross(moveDirection, wallHit.normal);


    }

    private void Look()
    {
        //Check for input against deadzone
        Vector2 joystickInput = new Vector2(Input.GetAxis("HorizontalR"), Input.GetAxis("VerticalR"));

        if (joystickInput.magnitude < deadzone)
        {
            joystickInput = Vector2.zero;
        }
        else
        {
            joystickInput = joystickInput.normalized * ((joystickInput.magnitude - deadzone) / (1 - deadzone));
            pitch = pCamera.transform.eulerAngles.x;

            //Check if the pitch has gone past the upper and lower bounds
            if (pitch > 30 && pitch < 180)
            {
                if (joystickInput.y < 0)
                    pCamera.transform.eulerAngles += new Vector3(joystickInput.y * lookSpeed, 0, 0);
            }
            else if(pitch < 330 && pitch > 180)
            {
                if(joystickInput.y > 0)
                    pCamera.transform.eulerAngles += new Vector3(joystickInput.y * lookSpeed, 0, 0);
            }
            else
                pCamera.transform.eulerAngles += new Vector3(joystickInput.y * lookSpeed, 0, 0);

        } 
            //Rotate if looking around
            transform.Rotate(0, joystickInput.x * lookSpeed, 0);
    }

    private void Jump()
    {
        if (grounded && !wallRunning)            //Standard Jump
        {
            Debug.Log("Normal Jump");
            rb3d.AddForce(new Vector3(0, 250, 0));

        }
        else if (wallRunning)    //Jump off from wall
        {
            Debug.Log("WallJump");
            if (wallOnRight)
            {
                rb3d.useGravity = true;
                rb3d.AddRelativeForce(new Vector3(-250, 200, 0));
            }
            else
            {
                rb3d.useGravity = true;
                rb3d.AddRelativeForce(new Vector3(250, 200, 0));
            }

            wallRunning = false;

        }
        else                    //Attempt to wallrun
        {
            Debug.Log("Wallrunning");
            wallRunning = CheckForWall();
        }
    }
}

