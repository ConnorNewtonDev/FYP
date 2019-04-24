using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeFour : ChallengeBase
{
    private List<GameObject> targets;
    
    private GameObject exit;
    public GameObject standardLayout;
    public GameObject hardmodeLayout;
 
    public override void Start()
    {
        base.Start();

        // if(base.GetHardMode(2))
        //     Instantiate(hardmodeLayout, this.transform.position,this.transform.rotation);
        // else
        //     Instantiate(standardLayout, this.transform.position,this.transform.rotation);

        Instantiate(hardmodeLayout, this.transform.position, this.transform.rotation);
        exit = GameObject.FindGameObjectWithTag("Finish");
        base.cameraStatic = true;

    }

    void Update()
    {

    }

    private void LoadHardMode()
    {
        
    }

    private void LoadStandard()
    {
        
    }

    public void OpenDoor()          //Check if all blocks in place, if so continue to open door.          
    {

        exit.SetActive(false);
        Debug.Log("Door Open");
    }

}
