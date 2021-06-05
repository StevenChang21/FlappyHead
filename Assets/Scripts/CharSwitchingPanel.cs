using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSwitchingPanel : MonoBehaviour
{
    [SerializeField] private SpriteData[] _AllSprites;
    [SerializeField] private Image _CurrentSelectedImageDisplay;
    private int _currentSpriteIndex = 0;
    private static SpriteData _selectedSprite;
    public static SpriteData SelectedSprite => _selectedSprite;

    void Start()
    {
        _CurrentSelectedImageDisplay.sprite = _AllSprites[0].Sprite;
        _CurrentSelectedImageDisplay.rectTransform.sizeDelta = _AllSprites[0].Dimension;
        _selectedSprite = _AllSprites[0];
    }

    public void OnClickNext(int difference)
    {
        _currentSpriteIndex += difference;
        if (_currentSpriteIndex >= _AllSprites.Length)
        {
            _currentSpriteIndex = 0;
        }
        if (_currentSpriteIndex < 0)
        {
            _currentSpriteIndex = _AllSprites.Length - 1;
        }
        _CurrentSelectedImageDisplay.sprite = _AllSprites[_currentSpriteIndex].Sprite;
        _CurrentSelectedImageDisplay.rectTransform.sizeDelta = _AllSprites[_currentSpriteIndex].Dimension;
        _selectedSprite = _AllSprites[_currentSpriteIndex];
    }

    public void OnClickHomeButton()
    {
        StartCoroutine(WaitUIEffectsEnd(() => SceneManager.LoadScene(0)));
    }

    private System.Collections.IEnumerator WaitUIEffectsEnd(System.Action action)
    {
        yield return new WaitForSeconds(0.5f);
        action?.Invoke();
    }
}

[System.Serializable]
public class SpriteData
{
    [SerializeField] private Sprite _Sprite;
    [SerializeField] private Vector2 _Dimension;

    public Sprite Sprite => _Sprite;
    public Vector2 Dimension => _Dimension;
}