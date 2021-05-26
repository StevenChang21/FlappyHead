using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] ObstacleGenerator generator;
    [SerializeField] GameObject DedUI;
    [SerializeField] TextMeshProUGUI score_Text;
    int _score;
    Transform _previousHitTransform;
    public int Score => _score;
    public bool IsDead { get; private set; }

    void Start()
    {
        IsDead = false;
    }

    void Update()
    {
        var raycast_hit = Physics2D.Raycast(transform.position, Vector3.down, 100f);
        if (raycast_hit.transform == null) { return; }
        if (raycast_hit.transform == _previousHitTransform) { return; }
        if (raycast_hit.transform.gameObject.CompareTag("Obstacle"))
        {
            _previousHitTransform = raycast_hit.transform;
            _score++;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GetComponent<PlayerMovement>().enabled = false;
        score_Text.text = $"Score: {_score}";
        DedUI.SetActive(true);
    }

}
