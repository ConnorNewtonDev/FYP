using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeTwo : ChallengeBase
{
    public GameObject[] boulderSpawners;
    public GameObject[] flameSpawners;

    private bool leftSpawn = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Init()
    {
        if (base.GetHardMode())
        {
            LoadHardMode();           //Activate Flamethrowers
        }
        else
            LoadStandard();           //Activate Boulders
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void LoadHardMode()
    {
        float diff = 1.25f;
        int index = 1;
        foreach (GameObject spawner in flameSpawners)
        {
            //spawner.GetComponent<Spawner>().enabled = true;
            spawner.GetComponent<Spawner>().SetStartCurTimer(diff * index);
            index++;
        }

        
        LoadStandard();             //Activate Boulders
    }

    private void LoadStandard()
    {
        float diff = 2f;
        int index = 1;
        foreach (GameObject spawner in boulderSpawners)
        {
            //spawner.GetComponent<Spawner>().enabled = true;
            spawner.GetComponent<Spawner>().SetStartCurTimer(diff * index);
            index++;
        }

    }

}
