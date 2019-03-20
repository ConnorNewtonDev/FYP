using UnityEngine;
using System.Collections;
public class ChallengeBase : MonoBehaviour
{
    public Transform spawnParent;
    public Transform playerSpawn;
    [SerializeField]
    public GameManager gM;


    public virtual void Start()
    {
        gM = FindObjectOfType<GameManager>();
        gM.cameraController = FindObjectOfType<Camera_Controller>();
    }

    public bool GetHardMode(int index)
    { return gM.hardmodeChoice[index]; }

    public IEnumerator Spawn(float _waitTime)
    {
        Debug.Log("HIT");
        yield return new WaitForSeconds(_waitTime);
        GameObject player =  Instantiate(gM.playerPrefab, playerSpawn.position, playerSpawn.rotation, null);
        player.name = "Player";
        player.GetComponent<Player>().gM = this.GetComponent<GameManager>();
        //Check if respawning & death panel still active
        if(gM.cameraController.deathPanel.activeInHierarchy)
            gM.cameraController.StartCoroutine(gM.cameraController.FadeUI(gM.cameraController.deathPanel, 1, 0));
        
    }
}
