using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager audio_manager_instance;
    [SerializeField] private AudioClip[] _AudioClips;
    [SerializeField] private AudioSource _AudioSource;
    private int _previousIndex = 0;

    public AudioSource AudioSource => _AudioSource;

    void Start()
    {
        DontDestroyOnLoad(this);

        if (audio_manager_instance == null)
        {
            audio_manager_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!_AudioSource.isPlaying)
        {
            _AudioSource.clip = _AudioClips[GetAudioClipIndex()];
            _AudioSource.Play();
        }
    }

    private int GetAudioClipIndex()
    {
        var new_index = Random.Range(0, _AudioClips.Length);
        while (_previousIndex == new_index)
        {
            new_index = Random.Range(0, _AudioClips.Length);
        }
        _previousIndex = new_index;
        return new_index;
    }

    public void PlayNextMusicClip()
    {
        _AudioSource.clip = _AudioClips[GetAudioClipIndex()];
        _AudioSource.Play();
    }
}
