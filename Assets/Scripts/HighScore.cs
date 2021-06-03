using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour, IKeyable
{
    [SerializeField] private TextMeshProUGUI _HighScoreLabel;
    [SerializeField] private string _Key;

    public string Key { get => _Key; set => _Key = value; }

    void Start()
    {
        SaveManager.Load();
    }

    public object CaptureState()
    {
        return null;
    }

    public void RestoreState(object state)
    {
        _HighScoreLabel.text = $"Highest Score: {(int)state}";
    }
}
