using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool[] _hardmodeChoice = new bool[10];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetHardmodeChoice(int loc, bool value)
    {
        _hardmodeChoice[loc] = value;
    }

}
