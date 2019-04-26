using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public bool[] hardmodeChoice = new bool[5];
    public int[] finalLife = new int[5];
    public int activeChallenge = 0;
    public GameObject playerPrefab;
    public Camera_Controller cameraController;
    public Transform respawnLoc;
    public int life;



    private void Awake()
    {
        if (instance == null)
          { 
               instance = this;
               DontDestroyOnLoad(gameObject);
               return;
          }
          if (instance == this) return; 
          Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {     
        cameraController = Camera.main.GetComponent<Camera_Controller>();
        life = 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            FinishedLevel();
    }


    public void FinishedLevel()
    {
        finalLife[activeChallenge - 1] = life; //Life of level just completed
        LoadScene(0);
    }

    public void LoadNextScene(bool hardMode)
    {
        hardmodeChoice[activeChallenge] = hardMode;
        life = 3;
        activeChallenge += 1;
        SceneManager.LoadScene(activeChallenge);
    }  

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
