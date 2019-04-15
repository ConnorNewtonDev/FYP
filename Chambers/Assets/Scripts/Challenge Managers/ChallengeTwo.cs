using UnityEngine;

public class ChallengeTwo : ChallengeBase
{
    public GameObject[] boulderSpawners;
    public GameObject[] flameSpawners;
    

    public override void Start()
    {
        base.Start();
        if(base.GetHardMode(2))
            LoadHardMode();           //Activate Flamethrowers        
        else
            LoadStandard();           //Activate Boulders

    }

    private void LoadHardMode()
    {
        float diff = 2.5f;
        int index = 1;
        foreach (GameObject spawner in flameSpawners)
        {
            spawner.GetComponentInChildren<Spawner>().Init(diff * index, base.spawnParent);
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
            spawner.GetComponent<Spawner>().Init(diff * index, base.spawnParent);
            index++;
        }

    }

}
