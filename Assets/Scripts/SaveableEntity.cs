using UnityEngine;

public class SaveableEntity : MonoBehaviour
{
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
