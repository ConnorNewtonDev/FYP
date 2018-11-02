using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<GameObject> interactables;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"))
            TryInteract();
    }

    void TryInteract()
    {
        interactables[0].GetComponent<Interactable>().Behaviour();
        interactables.RemoveAt(0);
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
