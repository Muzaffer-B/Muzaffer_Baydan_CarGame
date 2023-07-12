using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class SaveData
{
    public bool[] isActive;
    //public int[] highScores;
}
public class GameData : MonoBehaviour
{
    public static GameData gameData;
    public SaveData saveData;
    // Start is called before the first frame update
 

    private void Awake()
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
        //if (!File.Exists(Application.persistentDataPath + "/player.dat"))
        //{
        //    Save();
        //}
        Load();
    }

   
    public void Save()
    {
        // Create a binary formetter.
        BinaryFormatter formatter = new BinaryFormatter();
        // Create a route from the program to a file
        FileStream file = File.Open(Application.persistentDataPath + "/player.dat",FileMode.Create);

        //create a copy save data
        SaveData data = new SaveData();
        data = saveData;
        // Actually save the data in the file
        formatter.Serialize(file, data);

        // Close the data stream
        file.Close();
    }

    public void Load()
    {
        // check if the save game file exist
        if(File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            //create a binary formatter
            BinaryFormatter formatter= new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
            saveData = formatter.Deserialize(file) as SaveData;
            file.Close();
        }
    }

    //private void OnDisable()
    //{
    //    Save();
    //}



}
