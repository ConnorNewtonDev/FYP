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
        GameObject path;
        if (base.GetHardMode(5))
            path = Instantiate(hardmodeLayout, pathHolder.position, pathHolder.rotation);
        else
            path = Instantiate(standardLayout, pathHolder.position, pathHolder.rotation);

        path.name = "Path";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartEnemies()
    {
        Debug.Log("HIT");
        FindObjectOfType<EnemySpawner>().isSpawning = true;
    }

    public void FailedLevel()
    {
        gM.FailedLevel(6);
    }
}
