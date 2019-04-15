using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeThree : ChallengeBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if(base.GetHardMode(2))
            LoadHardMode();           //Activate Flamethrowers        
        else
            LoadStandard();           //Activate Boulders
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadHardMode()
    {

    }

    private void LoadStandard()
    {
        
    }

}
