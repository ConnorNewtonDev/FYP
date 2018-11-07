using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1_PathReveal : MonoBehaviour
{
    private bool triggered = false;
    public GameObject dissolveParent;
    // Start is called before the first frame update
    void Start()
    {
        dissolveParent = GameObject.Find("Dissolve");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(!triggered)
            {
                Player_Movement pM = other.GetComponent<Player_Movement>();
                StartCoroutine(Reveal(pM));
                triggered = true;
            }

        }
    }

    private IEnumerator Reveal(Player_Movement pM)
    {
        //Set player to remain stationary
        pM.inControl = false;                
        //Dissolve All Out
        for(int i = 0; i < dissolveParent.transform.childCount; i++)
        {
            StartCoroutine(dissolveParent.transform.GetChild(i).GetComponent<Dissolve>().ToggleDisolve(1));
        }
        //Pause to show player path
        yield return new WaitForSeconds(3);
        //Dissolve the tiles back in.
        for (int i = 0; i < dissolveParent.transform.childCount; i++)
        {
            StartCoroutine(dissolveParent.transform.GetChild(i).GetComponent<Dissolve>().ToggleDisolve(0));
        }

        pM.inControl = true;
        
    }
}
