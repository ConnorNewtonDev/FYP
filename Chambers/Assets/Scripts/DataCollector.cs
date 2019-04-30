using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class DataCollector : MonoBehaviour
{
    // Start is called before the first frame update
    private bool dataRights = false;
    private int[] sliderData = new int[8];
    private PlayerData playerData;

    public Slider[] sliders = new Slider[8];


    // This function could be extended easily to handle any additional data we wanted to store in our PlayerProgress object
    public void SaveFormScene()
    {
        playerData = new PlayerData();

        playerData.rights = dataRights;
        // Loop through values of slliderData to be stored and used later.
        
        for(int i = 0; i < sliderData.Length; i++)
            playerData.sliderData[i] = sliders[i].value.ToString(); 

    }

    public void SaveGameData(GameManager gM)
    {
        // Cast bool to string for the right to retain and use the data.
        for(int j = 0; j < gM.hardmodeChoice.Length; j++)
            playerData.hardmodeChoice[j] = gM.hardmodeChoice[j];

        // Loop through values of slliderData to be stored and used later.
        for(int i = 0; i < gM.finalLife.Length; i++)
            playerData.finalLife[i] = gM.finalLife[i];


        StoreData();
    }

    public void StoreData()
    {
        string dataAsJson = JsonUtility.ToJson (playerData);

        string filePath = Application.dataPath + "/Report.data";
        File.WriteAllText (filePath, dataAsJson);
        
        filePath = Application.persistentDataPath + "/Report.data";
               File.WriteAllText (filePath, dataAsJson);
        Debug.Log("Data Stored");
    }



[Serializable]
    class PlayerData
    {
        public bool rights;
        public string[] sliderData = new string[9];
        public bool[] hardmodeChoice = new bool[5];
        public int[] finalLife = new int[5];
    }
}

