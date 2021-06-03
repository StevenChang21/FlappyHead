using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string _savePath => Application.persistentDataPath + "/Saves.txt";

    public static void Save()
    {
        var state = LoadFile();
        CaptureState(state);
        SaveFile(state);
    }

    public static void Load()
    {
        var state = LoadFile();
        RestoreState(state);
    }

    // public static void LoadWithKey(string key)
    // {
    //     var state = LoadFile();
    //     foreach (var saveable in FindObjectsOfType<SaveableEntity>())
    //     {
    //         foreach (var data in saveable.Keyables)
    //         {
    //             if (key == data.Key.Key)
    //             {
    //                 if (!state.TryGetValue(key, out object value))
    //                 {
    //                     Debug.Log("No data");
    //                 }
    //                 saveable.Keyables[data.Key] = value;
    //             }
    //         }
    //     }
    // }

    private static void SaveFile(object state)
    {
        using (var stream = File.Open(_savePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    private static Dictionary<string, object> LoadFile()
    {
        if (!File.Exists(_savePath))
        {
            Debug.Log("File not existed");
            return new Dictionary<string, object>();
        }

        using (FileStream stream = File.Open(_savePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }
    }

    private static void RestoreState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            foreach (var keyable in saveable.GetComponents<IKeyable>())
            {
                if (!state.TryGetValue(keyable.Key, out var value))
                {
                    Debug.Log("No data");
                    continue;
                }
                keyable.RestoreState(value);
            }
        }
    }

    private static void CaptureState(Dictionary<string, object> state)
    {
        var all_saveable_entity = FindObjectsOfType<SaveableEntity>();
        foreach (var saveable in all_saveable_entity)
        {
            foreach (var keyable in saveable.GetComponents<IKeyable>())
            {
                state[keyable.Key] = keyable.CaptureState();
            }
        }
    }
}
