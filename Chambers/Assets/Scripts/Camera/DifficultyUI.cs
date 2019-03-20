using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyUI : MonoBehaviour
{
    private GameManager gameManager;
    private Player_Movement pMovement;
    private Camera_Controller cameraController;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }       

    public void StandardBtn()
    {
        gameManager.LoadNextScene(false);
    }

    public void HardmodeBtn()
    {
        gameManager.LoadNextScene(true);
    }
}
