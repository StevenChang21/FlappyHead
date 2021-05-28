using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour, ISaveable
{
    [SerializeField] TextMeshProUGUI _scoreLabel;
    [SerializeField] Player _player;
    private int _HighScore;

    void Update()
    {
        if (_player.IsDead) { enabled = false; }
        _scoreLabel.text = _player.Score.ToString();
    }

    public object CaptureState()
    {
        if (_player.Score > _HighScore)
        {
            Debug.Log($"New high score:{_player.Score}");
            GameManager.HighScore = _player.Score;
            return _player.Score;
        }
        return _HighScore;
    }

    public void RestoreState(object state)
    {
        _HighScore = (int)state;
        Debug.Log($"Current high score:{_HighScore}");
    }
}
