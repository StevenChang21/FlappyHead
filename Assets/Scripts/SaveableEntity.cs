using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveableEntity : MonoBehaviour
{
    public IKeyable Keyable;
    [SerializeField] private string id;
    public string Id => id;

    [ContextMenu("Generate id")]
    private void GenerateId() => id = Guid.NewGuid().ToString();

    public object CaptureState()
    {
        var state = new Dictionary<string, object>();
        foreach (var saveable in GetComponents<ISaveable>())
        {
            state[saveable.GetType().ToString()] = saveable.CaptureState();
        }
        Debug.Log(state.Count);
        return state;
    }

    public void RestoreState(object state)
    {
        var state_dictionary = (Dictionary<string, object>)state;
        foreach (var saveable in GetComponents<ISaveable>())
        {
            saveable.RestoreState(state_dictionary[saveable.GetType().ToString()]);
        }
    }
}

public interface ISaveable
{
    object CaptureState();
    void RestoreState(object state);
}

public interface IKeyable : ISaveable
{
    public string Key { get; set; }
}
