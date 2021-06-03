using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IKeyable
{

    [SerializeField] private SpriteRenderer _PlayerImage;
    [SerializeField] private VoidEvent _OnPlayerDead;
    [SerializeField] private IntVariable _PlayerScoreReference;
    Transform _previousHitTransform;
    [SerializeField] private string _key;
    private int _score;
    public string Key { get => _key; set => _key = value; }

    void Awake()
    {
        _PlayerScoreReference.Value = 0;
        _OnPlayerDead.Event.AddListener(OnPlayerDead);
        if (MainMenu.HeadSprite != null)
        {
            _PlayerImage.sprite = MainMenu.HeadSprite;
        }
    }

    void Start()
    {
        SaveManager.Load();
    }

    void Update()
    {
        var raycast_hit = Physics2D.Raycast(transform.position, Vector3.down, 100f);
        if (raycast_hit.transform == null) { return; }
        if (raycast_hit.transform == _previousHitTransform) { return; }
        if (raycast_hit.transform.gameObject.CompareTag("Obstacle"))
        {
            _previousHitTransform = raycast_hit.transform;
            _PlayerScoreReference.Value++;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        _OnPlayerDead.Event?.Invoke();
    }

    void OnPlayerDead()
    {
        SaveManager.Save();
    }

    public object CaptureState()
    {
        if (_score < _PlayerScoreReference.Value)
        {
            return _PlayerScoreReference.Value;
        }
        return _score;
    }

    public void RestoreState(object state)
    {
        _score = (int)state;
    }
}
