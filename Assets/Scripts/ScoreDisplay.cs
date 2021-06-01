using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private VoidEvent _ListenerOnPlayerDied;
    [SerializeField] private IntVariable _PlayerScore;
    [SerializeField] TextMeshProUGUI _scoreLabel;

    void Start()
    {
        _ListenerOnPlayerDied.Event.AddListener(OnPlayerDied);
    }

    void Update()
    {
        _scoreLabel.text = _PlayerScore.Value.ToString();
    }

    private void OnPlayerDied()
    {
        _scoreLabel.text = _PlayerScore.Value.ToString();
        enabled = false;
    }
}
