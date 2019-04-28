using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeFive : ChallengeBase
{
    // Start is called before the first frame update
    public Transform pathHolder;
    public GameObject standardLayout;
    public GameObject hardmodeLayout;
    public override void Start()
    {
        base.Start();
        
        if (base.GetHardMode(2))
            Instantiate(hardmodeLayout, pathHolder.position, pathHolder.rotation);
        else
            Instantiate(standardLayout, pathHolder.position, pathHolder.rotation);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEnemies()
    {
        pathHolder.GetComponentInChildren<EnemySpawner>().isSpawning = true;
    }

    public void FailedLevel()
    {
        gM.FailedLevel(6);
    }
}
