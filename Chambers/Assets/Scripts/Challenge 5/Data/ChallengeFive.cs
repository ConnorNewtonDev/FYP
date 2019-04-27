using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeFive : ChallengeBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEnemies()
    {
        GetComponent<EnemySpawner>().isSpawning = true;
    }

    public void FailedLevel()
    {
        gM.FailedLevel();
    }
}
