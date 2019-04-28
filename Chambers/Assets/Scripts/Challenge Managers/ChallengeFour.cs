using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeFour : ChallengeBase
{
    private List<GameObject> targets;
    private GameObject hardmodeDoor;
    public GameObject standardLayout;
    public GameObject hardmodeLayout;
    private int pickups;

    public override void Start()
    {
        base.Start();

        if(base.GetHardMode(2))
        {
            Debug.Log("HardMode");
            Instantiate(hardmodeLayout, this.transform.position,this.transform.rotation);
            hardmodeDoor = GameObject.Find("Exit");
        }
        else
            Instantiate(standardLayout, this.transform.position,this.transform.rotation);

        base.cameraStatic = true;

    }

    void Update()
    {

    }
    public void PickupCollected()
    {
        pickups -= 1;
        if(pickups == 0)
            hardmodeDoor.SetActive(false);
    }
}
