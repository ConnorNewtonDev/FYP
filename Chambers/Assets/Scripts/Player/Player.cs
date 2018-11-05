﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> interactables;

    // Start is called before the first frame update
    void Start()
    {
        interactables = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"))
            TryInteract();
    }

    void TryInteract()
    {
        interactables[0].GetComponent<Interactable>().Action();

        if(!interactables[0].GetComponent<Interactable>().destroyOnUse)
        {
            //Make sure not stuck in loop of only using 1 item, puts to back of list if multiple in range.
            interactables.Add(interactables[0]);
            interactables.RemoveAt(0);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Interactable":
                    interactables.Add(other.gameObject);
                    break;

        }
    }
}
