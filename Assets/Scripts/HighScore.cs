using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour, ISaveable
{
    [SerializeField] private TextMeshProUGUI _HighScoreLabel;
    [SerializeField] private string _Key;

    public string Key { get => _Key; set => throw new System.NotImplementedException(); }

    public object CaptureState()
    {
        throw new System.NotImplementedException();
    }

    public void RestoreState(object state)
    {
        throw new System.NotImplementedException();
    }
}
