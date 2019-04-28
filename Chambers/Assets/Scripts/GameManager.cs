using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private DataCollector data;
    public bool[] hardmodeChoice = new bool[5];
    public int[] finalLife = new int[5];
    public int[] bonusPts = new int[5];
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
        data =  GetComponent<DataCollector>();
        cameraController = Camera.main.GetComponent<Camera_Controller>();
        life = 3;
    }

    public int GetFinalPoints()
    {
        int sum = 0;
        foreach(int val in finalLife)
        {
            sum += val;
        }
        foreach(int val in bonusPts)
        {
            sum += val;
        }

        return sum;

    }

    public void FinishedLevel(int nextSceneIndex, bool shouldSave)
    {            
        finalLife[activeChallenge - 1] = life; //Life of level just completed

        HandleBonusRewards();

        if(shouldSave == true)
           data.SaveGameData(this);

        LoadScene(nextSceneIndex);
    }

    private void HandleBonusRewards()
    {
    switch(activeChallenge)
    {
        case 1:
            if(hardmodeChoice[activeChallenge - 1] == true)
                bonusPts[activeChallenge -1] = 1;            
            break;
        case 2:
            bonusPts[activeChallenge -1] = 0;            
            break;
        case 3:
            if(hardmodeChoice[activeChallenge - 1] == true)
                if(life == 3)
                    bonusPts[activeChallenge -1] = 2;            
                else
                    bonusPts[activeChallenge -1] = -1;
            break;  
        case 4:
            if(hardmodeChoice[activeChallenge - 1] == true)
                bonusPts[activeChallenge -1] = 4;            
            break;            
        case 5:
            if(hardmodeChoice[activeChallenge - 1] == true)
                if(life == 3)
                    bonusPts[activeChallenge -1] = 3;            
                else
                    bonusPts[activeChallenge -1] = -3;       
            break;
    }
    }

    public void FailedLevel(int nextSceneIndex)
    {
           if (life == 1)
        {          
            life -= 1;
            //Reload --- still to decide here what to do
            LoadScene(nextSceneIndex);
        }
        else
        {
            life -= 1;
            ReloadScene();
        }
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

    public void BeginGame()
    {
        GetComponent<DataCollector>().SaveFormScene();
        LoadScene(7);
    }

    

}
