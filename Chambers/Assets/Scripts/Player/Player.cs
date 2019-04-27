using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Player_Movement pMovement;
    public GameManager gM;
    public delegate void InteractDel();
    public event InteractDel interactEvent;

    void Start()
    {
        pMovement = GetComponent<Player_Movement>();
        gM = FindObjectOfType<GameManager>();



    }

    void Update()
    {
        if (Input.GetButtonDown("Action") && pMovement.inControl == true)
            TryInteract();
    }

    void TryInteract()
    {
        if(interactEvent != null)
            interactEvent();        
    }

#region Collision
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Interactable":
                    //interactables.Add(other.gameObject);
                    interactEvent += other.GetComponent<Interactable>().Action;
                    break;
            case "DestroyPlayer":
                    DestroySequence();
                    break;
            case "Finish":
                    gM.FinishedLevel(7, false);
                    break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch(other.tag)
        {
            case "Interactable":
                    //interactables.Remove(other.gameObject);
                    interactEvent -= other.GetComponent<Interactable>().Action;
                    other.GetComponent<Interactable>().EndAction();
                    break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "DestroyPlayer")
        {
            DestroySequence();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "DestroyPlayer")
        {
            DestroySequence();
        }
    }
#endregion

    private void DestroySequence()
    {
        pMovement.inControl = false;
        pMovement.DeathScreen();
        this.transform.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<AudioSource>().Play();

        gM.FailedLevel(7);       

    }

}
