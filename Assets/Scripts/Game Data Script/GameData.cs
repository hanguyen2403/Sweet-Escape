using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class SaveData
{
    public bool[] isActive;
    public int[] highScores;
    public int[] stars;
}

public class GameData : MonoBehaviour
{
    public static GameData gameData;
    public SaveData saveData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (gameData == null)
        {
            DontDestroyOnLoad(this.gameObject);
            gameData = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Load();
    }

    private void Start()
    {

    }
    public void Save()
    {
        //Create a binary formatter which can read binary files
        BinaryFormatter formatter = new BinaryFormatter();
        //Create a route fromt he program to the file
        FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Create);
        //Create a copy of save data
        SaveData data = new SaveData();
        data = saveData;
        //Actually save the data in the file
        formatter.Serialize(file, data);
        file.Close();
        Debug.Log("Saved");
    }
    public void Load()
    {
        //Check if the file exists
        if (File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            //Create a binary formatter which can read binary files
            BinaryFormatter formatter = new BinaryFormatter();
            //Create a route fromt he program to the file
            FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
            //Create a copy of save data
            saveData = formatter.Deserialize(file) as SaveData;
            file.Close();
            Debug.Log("Loaded");
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    private void OnDisable()
    {
        Save();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
