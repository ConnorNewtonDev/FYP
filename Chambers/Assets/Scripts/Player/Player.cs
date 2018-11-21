using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public List<GameObject> interactables;
    private Player_Movement pMovement;
    public GameManager gM;


    // Start is called before the first frame update
    void Start()
    {
        pMovement = GetComponent<Player_Movement>();
        interactables = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Action") && pMovement.inControl == true && interactables.Count != 0)
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

    private void OnTriggerExit(Collider other)
    {
        switch(other.tag)
        {
            case "Interactable":
                    interactables.Remove(other.gameObject);
                    break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "DestroyPlayer")
        {
            DestroySequence();
        }
    }

    private void DestroySequence()
    {
        pMovement.inControl = false;
        if (gM.life == 1)
        {
            pMovement.DeathScreen();
        }
        else
        {
            gM.life--;     
            pMovement.DeathScreen();
            gM.StartCoroutine(gM.Spawn(3));                        //Spawn player in 3 seconds
            Destroy(this.gameObject);                              //Delete player behind screen
                                                                   //Make it look good
        }



    }

}
