using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyUI : MonoBehaviour
{
    public GameObject activeChallenge;
    private Player_Movement pMovement;
    private Camera_Controller cameraController;

    private void Start()
    {
        pMovement = FindObjectOfType<Player_Movement>();
        cameraController = Camera.main.GetComponent<Camera_Controller>();
    }

    public void StandardBtn()
    {
        activeChallenge.GetComponent<ChallengeBase>().SetHardMode(false);
        activeChallenge.GetComponent<ChallengeBase>().Init();
        pMovement.inControl = true;
        //Fade UI Out
        StartCoroutine(cameraController.FadeUI(this.gameObject, 1, 0));
    }

    public void HardmodeBtn()
    {
        activeChallenge.GetComponent<ChallengeBase>().SetHardMode(true);
        activeChallenge.GetComponent<ChallengeBase>().Init();
        pMovement.inControl = true;
        //Fade UI Out
        StartCoroutine(cameraController.FadeUI(this.gameObject, 1, 0));
    }
}
