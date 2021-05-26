using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image _ImageRef;
    [SerializeField] TextMeshProUGUI _scoreLabel;
    private int highestScore;
    Sprite playerHeadImage;
    Player player;

    public int HighestScore
    {
        get => highestScore;
        set
        {
            _scoreLabel.text = $"Highest Score: {value}";
            highestScore = value;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnClickPlay()
    {
        playerHeadImage = _ImageRef.sprite;
        SceneManager.LoadScene(1);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            if (highestScore < player.Score)
            {
                highestScore = player.Score;
                _scoreLabel = GameObject.Find("Score_Text (TMP)").GetComponent<TextMeshProUGUI>();
                _scoreLabel.text = $"Highest Score: {highestScore}";
            }
        }
        if (scene.buildIndex == 1)
        {
            player = FindObjectOfType<Player>();
            player.GetComponent<SpriteRenderer>().sprite = playerHeadImage;
        }
    }
}
