using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float _FowardAcceleration;
    [SerializeField] float _UpForce = 5f;
    [SerializeField] float _Gravity;
    [SerializeField] float _MaxGravity;
    [SerializeField] Rigidbody2D _rb;
    Vector2 velocity;

    void Start()
    {
        velocity.x = 5f;
    }

    void Update()
    {
        velocity.x += _FowardAcceleration * Time.deltaTime;
        velocity.y += _Gravity;
        if (Input.GetKey(KeyCode.Space))
        {
            velocity.y += _UpForce;
        }
        velocity.y = Mathf.Clamp(velocity.y, _MaxGravity, -_MaxGravity);
        transform.Translate(velocity * Time.deltaTime);
        var y_pos = Mathf.Clamp(transform.position.y, -4f, 4f);
        transform.position = new Vector3(transform.position.x, y_pos, 0f);
    }
}
