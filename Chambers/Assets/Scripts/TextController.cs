using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    private GameManager gM;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI bonusText;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();

        titleText.text = SetTitle();
        descText.text  = SetDescription();
        bonusText.text = SetBonus();

    }

    private string SetTitle()
    {
        string output = "";

        switch(gM.activeChallenge)
        {
            case 0:
                output = "Memory Test";
                break;
            case 1:
                output = "Reactionary";
                break;
            case 2: 
                output = "Puzzle Champ";
                break;
            case 3:
                output = "Timings";
                break;
            case 4:
                output = "Defend The Road";
                break;
        }
        return output;
    }

    private string SetDescription()
    {
        string output = "";

        switch(gM.activeChallenge)
        {
            case 0:
                output = "Approach the hole for the path to appear, remember it, and most importantly dont take a wrong turn!";
                break;
            case 1:
                output = "QUICK! Get up the hill, who knows what is falling from above!";
                break;
            case 2: 
                output = "Push the blocks into the target areas...";
                break;
            case 3:
                output = "Quiet now, sneak through here and get the cube to get out the other side, don't be seen!";
                break;
            case 4:
                output = "The towers have a shared power! The more you use the weaker they become, destroy them to regain power!";
                break;
        }
        return output;
    }

    private string SetBonus()
    {
        string output = "";

        switch(gM.activeChallenge)
        {
            case 0:
                output = "+1 Bonus Point";
                break;
            case 1:
                output = "NO BONUS";
                break;
            case 2: 
                output = "+2 Bonus Points if completed first try, otherwise -1 Bonus Points";
                break;
            case 3:
                output = "+4 Bonus Points";
                break;
            case 4:
                output = "+3 Bonus Points if completed first try, otherwise -3 Bonus Points";
                break;
        }
        return output;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
