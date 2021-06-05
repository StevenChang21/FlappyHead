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
        _ListenerOnPlayerDead.Event.AddListener(OnPlayerDied);
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnPlayerDied()
    {
        _ScoreLabel.text = $"Score: {_PlayerScore.Value}";
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnClickPlayAgain()
    {
        Time.timeScale = 1f;
        StartCoroutine(WaitUIEffectsEnd(() => SceneManager.LoadScene(1), 0.5f));
    }

    public void OnClickHome()
    {
        Time.timeScale = 1f;
        StartCoroutine(WaitUIEffectsEnd(() => SceneManager.LoadScene(0), 0.5f));
    }

    System.Collections.IEnumerator WaitUIEffectsEnd(System.Action action, float duration)
    {
        yield return new WaitForSeconds(duration);
        action.Invoke();
    }
}
