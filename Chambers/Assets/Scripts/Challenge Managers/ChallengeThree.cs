using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeThree : ChallengeBase
{
    private List<GameObject> targets;
    
    private GameObject exit;
    public GameObject standardLayout;
    public GameObject hardmodeLayout;
 
    public override void Start()
    {
        base.Start();

        if (base.GetHardMode(3))
            Instantiate(hardmodeLayout, this.transform.position, this.transform.rotation);
        else
            Instantiate(standardLayout, this.transform.position, this.transform.rotation);

        targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("CubeTarget"));
        exit = GameObject.FindGameObjectWithTag("Finish");
        base.cameraStatic = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gM.FailedLevel(7);
        }
    }

    public void OpenDoor()          //Check if all blocks in place, if so continue to open door.          
    {
        foreach(GameObject item in targets)
        {
            if(!item.GetComponent<CubeTarget>().GetFilledState())  { return; }
        }

        exit.SetActive(false);
        Debug.Log("Door Open");
    }

}
