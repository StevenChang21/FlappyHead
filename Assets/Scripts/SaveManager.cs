using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    GameManager manager;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void OnClickSave()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/Kalapucjj.virus";
        FileStream stream = new FileStream(path, FileMode.Create);
        binaryFormatter.Serialize(stream, manager.HighestScore);
        stream.Close();
    }

    public void OnLoadHighScore()
    {
        var path = Application.persistentDataPath + "/Kalapucjj.virus";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            manager.HighestScore = (int)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
