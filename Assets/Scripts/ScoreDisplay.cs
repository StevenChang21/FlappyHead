using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreLabel;
    [SerializeField] Player _player;

    void Update()
    {
        if (_player.IsDead) { enabled = false; }
        _scoreLabel.text = _player.Score.ToString();
    }
}
