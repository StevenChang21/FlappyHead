using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _RotationSpeed;
    [SerializeField] private VoidEvent _ListenerOnPlayerDied;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private Movement _Movement;
    Vector2 velocity;

    void Start()
    {
        _ListenerOnPlayerDied.Event.AddListener(OnPlayerDied);
        velocity.x = 2f;
        transform.localEulerAngles = new Vector3(0f, 0f, 90f);
    }

    void Update()
    {
        if (_Movement == null) { return; }
        velocity = _Movement.Move(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W), Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow), velocity);
        transform.Translate(velocity * Time.deltaTime, Space.World);
        float rot;
        if (velocity.y < 0)
        {
            rot = Mathf.LerpAngle(transform.localEulerAngles.z, 20f, _RotationSpeed * Time.deltaTime);
        }
        else
        {
            rot = Mathf.LerpAngle(transform.localEulerAngles.z, 0f, _RotationSpeed * Time.deltaTime);
        }
        var y_pos = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(transform.position.x, y_pos, 0f);
        transform.localEulerAngles = new Vector3(0f, 0f, rot);
    }

    private void OnPlayerDied()
    {
        _Movement = null;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
