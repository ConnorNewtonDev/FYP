using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool[] _hardmodeChoice = new bool[10];
    public Transform respawnLoc;
    public GameObject playerPrefab;
    public Camera_Controller cameraController;
    public int life;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = Camera.main.GetComponent<Camera_Controller>();
        StartCoroutine(Spawn(0));
        life = 3;
    }

    public void SetHardmodeChoice(int loc, bool value)
    {
        _hardmodeChoice[loc] = value;
    }

    public void LoadScene(Scene _scene)
    {
        SceneManager.LoadScene(_scene.name);
    }

    public IEnumerator Spawn(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        GameObject player =  Instantiate(playerPrefab, respawnLoc.position, respawnLoc.rotation, null);
        player.name = "Player";
        player.GetComponent<Player>().gM = this.GetComponent<GameManager>();
        //Check if respawning & death panel still active
        if(cameraController.deathPanel.activeInHierarchy)
            cameraController.StartCoroutine(cameraController.FadeUI(cameraController.deathPanel, 1, 0));
        
    }


}
