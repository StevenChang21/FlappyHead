using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _HighScoreLabel;
    [SerializeField] private Image _HeadImage;
    public static Sprite HeadSprite;

    void Start()
    {
        if (CharSwitchingPanel.SelectedSprite != null)
        {
            MainMenu.HeadSprite = CharSwitchingPanel.SelectedSprite.Sprite;
            _HeadImage.sprite = MainMenu.HeadSprite;
            _HeadImage.rectTransform.sizeDelta = CharSwitchingPanel.SelectedSprite.Dimension;
        }
        MainMenu.HeadSprite = _HeadImage.sprite;
    }

    public void OnClickPlay()
    {
        StartCoroutine(WaitUIEffectsEnd(() => SceneManager.LoadScene(1), 0.5f));
    }

    public void OnClickSwitchChar()
    {
        StartCoroutine(WaitUIEffectsEnd(() => SceneManager.LoadScene(2), 0.5f));
    }

    System.Collections.IEnumerator WaitUIEffectsEnd(System.Action action, float duration)
    {
        yield return new WaitForSeconds(duration);
        action.Invoke();
    }
}
