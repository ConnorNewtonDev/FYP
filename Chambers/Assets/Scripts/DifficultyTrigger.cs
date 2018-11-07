﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyTrigger : MonoBehaviour
{
    public GameObject Challenge;

    private Player_Movement pMovement;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Stop player moving
            pMovement = other.GetComponent<Player_Movement>();
            pMovement.inControl = false;


        }
    }
}