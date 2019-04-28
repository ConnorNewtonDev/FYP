using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinalScene : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI points;
    private GameManager gM;
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        points.text = gM.GetFinalPoints().ToString() + "/23 points";
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
