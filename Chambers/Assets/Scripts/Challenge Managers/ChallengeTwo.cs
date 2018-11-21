using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeTwo : ChallengeBase
{
    public GameObject[] boulderSpawners;
    public GameObject[] flameSpawners;

    private bool leftSpawn = true;
    public bool spawning = false;

    public float curTimer = 0;
    public float spawnTime;
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

    private void LoadHardMode()
    {
        float diff = 2.5f;
        int index = 1;
        foreach (GameObject spawner in flameSpawners)
        {
            spawner.GetComponent<Spawner>().SetStartCurTimer(diff * index);
            index++;
        }

        
        LoadStandard();             //Activate Boulders
    }

    private void LoadStandard()
    {
        float diff = 3f;
        int index = 1;
        foreach (GameObject spawner in boulderSpawners)
        {
            spawner.GetComponent<Spawner>().SetStartCurTimer(diff * index);
            index++;
        }

    }

}
