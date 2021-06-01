using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DedPopupPanel : MonoBehaviour
{
    [SerializeField] private VoidEvent _ListenerOnPlayerDead;
    [SerializeField] private IntVariable _PlayerScore;
    [SerializeField] private TextMeshProUGUI _ScoreLabel;

    void Start()
    {
        Debug.Log("Yay");
        _ListenerOnPlayerDead.Event.AddListener(OnPlayerDied);
        gameObject.SetActive(false);
    }

    private void OnPlayerDied()
    {
        Debug.Log("HI");
        _ScoreLabel.text = $"Score: {_PlayerScore.Value}";
        gameObject.SetActive(true);
    }

    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
