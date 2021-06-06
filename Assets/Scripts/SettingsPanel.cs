using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _SettingsPanel;
    [SerializeField] private Slider _VolumeSlider;
    [SerializeField] private Button _SkipMusicButton;
    void Start()
    {
        var audioManager = FindObjectOfType<AudioManager>();
        _VolumeSlider.onValueChanged.AddListener((float value) => audioManager.AudioSource.volume = value);
        _SkipMusicButton.onClick.AddListener(audioManager.PlayNextMusicClip);
        _SettingsPanel.SetActive(false);
    }
}
