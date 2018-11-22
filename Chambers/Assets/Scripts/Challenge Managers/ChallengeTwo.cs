using UnityEngine;

public class ChallengeTwo : ChallengeBase
{
    public GameObject[] boulderSpawners;
    public GameObject[] flameSpawners;
    

    public override void Init()
    {
        if(base.GetHardMode())
            LoadHardMode();           //Activate Flamethrowers        
        else
            LoadStandard();           //Activate Boulders

        base.SetActiveRespawn(playerSpawn);
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
