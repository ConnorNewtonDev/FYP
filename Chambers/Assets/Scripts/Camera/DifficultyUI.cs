using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyUI : MonoBehaviour
{
    public GameObject activeChallenge;
    private Player_Movement pMovement;

    private void Start()
    {
        pMovement = FindObjectOfType<Player_Movement>();
    }

    public void StandardBtn()
    {
        activeChallenge.GetComponent<ChallengeBase>().SetHardMode(false);
        activeChallenge.GetComponent<ChallengeBase>().Init();
        pMovement.inControl = true;
        Disable();
    }

    public void HardmodeBtn()
    {
        activeChallenge.GetComponent<ChallengeBase>().SetHardMode(true);
        activeChallenge.GetComponent<ChallengeBase>().Init();
        pMovement.inControl = true;
        Disable();
    }

    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
