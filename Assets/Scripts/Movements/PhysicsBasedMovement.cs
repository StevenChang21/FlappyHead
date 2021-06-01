using UnityEngine;

public class PhysicsBasedMovement : Movement
{
    private enum CalculationMode { velocity, acceleration };

    [SerializeField] float _FowardAcceleration = 0.1f;
    [SerializeField] float _UpForce = 15f;
    [SerializeField] float _Gravity = -9.81f;
    [SerializeField] float _MaxGravity = -5f;
    [SerializeField] private CalculationMode _Mode;
    private System.Func<float> _upVelocityModifier;

    void Start()
    {
        switch (_Mode)
        {
            case CalculationMode.velocity:
                _upVelocityModifier = GetOne;
                break;
            case CalculationMode.acceleration:
                _upVelocityModifier = GetDeltaTime;
                break;
        }
    }

    public override Vector2 Move(bool move_up, Vector2 velocity)
    {
        float up_velocity;
        velocity.x += _FowardAcceleration * Time.deltaTime;
        up_velocity = _Gravity;
        if (move_up)
        {
            up_velocity += _UpForce;
        }
        velocity.y += up_velocity * _upVelocityModifier();
        velocity.y = Mathf.Clamp(velocity.y, _MaxGravity, -_MaxGravity);
        return velocity;
    }

    private float GetOne()
    {
        return 1;
    }

    private float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}
