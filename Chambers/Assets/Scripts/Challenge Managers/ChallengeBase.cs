using UnityEngine;
using System.Collections;
public class ChallengeBase : MonoBehaviour
{
    public Transform spawnParent;
    public Transform playerSpawn;
    [SerializeField]
    public GameManager gM;
    public bool cameraStatic = false;


    public virtual void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    public bool GetHardMode(int index)
    { return gM.hardmodeChoice[index - 1]; }

    public IEnumerator Spawn(float _waitTime)
    {
        Destroy(GameObject.Find("Player"));
        yield return new WaitForSeconds(_waitTime);
        GameObject player =  Instantiate(gM.playerPrefab, playerSpawn.position, playerSpawn.rotation, null);
        player.name = "Player";
        player.GetComponent<Player>().gM = this.GetComponent<GameManager>();
        //Check if respawning & death panel still active

        
    }
}
