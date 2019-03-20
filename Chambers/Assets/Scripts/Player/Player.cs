using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        gM = FindObjectOfType<GameManager>();
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
            case "DestroyPlayer":
                    DestroySequence();
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

    private void DestroySequence()
    {
        pMovement.inControl = false;
        pMovement.DeathScreen();
        this.transform.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject, 2.5f);                              //Delete player behind screen

        if (gM.life == 1)
        {          
            gM.life -= 1;
            //Reload --- still to decide here what to do
            gM.LoadScene(0);
        }
        else
        {
            gM.life -= 1;
        }



    }

}
