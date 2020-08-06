
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem 
{

    public static void saveData(Game_Data Game_Data) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameData.Sav";  // sets save path relative to correct base destination
        FileStream stream = new FileStream(path, FileMode.Create);

        saveFile File = new saveFile(Game_Data);  // creates a new save file using current game data as input for the file

        formatter.Serialize(stream, File);
        stream.Close();
    }


    public static saveFile loadData()
    {
        
        string path = Application.persistentDataPath + "/gameData.Sav";
        if (File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           saveFile File =  formatter.Deserialize(stream) as saveFile;
           stream.Close();

            return File;
        }
        else  // error handling
        {
            Debug.LogError("Save file to load not found");
            return null;
        }


    }

}
