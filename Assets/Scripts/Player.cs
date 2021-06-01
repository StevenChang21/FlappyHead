using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, ISaveable
{

    [SerializeField] private SpriteRenderer _PlayerImage;
    [SerializeField] private VoidEvent _OnPlayerDead;
    [SerializeField] private IntVariable _PlayerScoreReference;
    Transform _previousHitTransform;

    void Awake()
    {
        _PlayerScoreReference.Value = 0;
        if (MainMenu.HeadSprite != null)
        {
            _PlayerImage.sprite = MainMenu.HeadSprite;
        }
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

    public object CaptureState()
    {
        if (GameManager.HighScore < _PlayerScoreReference.Value)
        {
            return _PlayerScoreReference.Value;
        }
        return GameManager.HighScore;
    }

    public void RestoreState(object state)
    {
        //Future use
    }
}
