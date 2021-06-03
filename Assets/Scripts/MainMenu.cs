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
        MainMenu.HeadSprite = _HeadImage.sprite;
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }
}
