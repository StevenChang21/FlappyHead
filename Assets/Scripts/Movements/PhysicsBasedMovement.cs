using UnityEngine;

public class PhysicsBasedMovement : Movement
{
    private enum CalculationMode { velocity, acceleration };

    [SerializeField] float _FowardAcceleration = 0.1f;
    [SerializeField] float _UpAcceleration = 0.05f;
    [SerializeField] float _MaxVelocityAcceleration = 0.01f;

    [SerializeField] float _UpForce = 15f;
    [SerializeField] float _Gravity = -9.81f;
    [SerializeField] float _MaxGravity = -5f;
    [SerializeField] private CalculationMode _Mode;

    public override Vector2 Move(bool move_up, Vector2 velocity)
    {
        float up_velocity;
        velocity = Accelerate(velocity);
        up_velocity = _Gravity;
        if (move_up)
        {
            up_velocity += _UpForce;
        }
        float modifier = 1;
        switch (_Mode)
        {
            case CalculationMode.velocity:
                modifier = 1;
                break;
            case CalculationMode.acceleration:
                modifier = Time.deltaTime;
                break;
        }
        velocity.y += up_velocity * modifier;
        velocity.y = Mathf.Clamp(velocity.y, _MaxGravity, -_MaxGravity);
        return velocity;
    }

    private Vector2 Accelerate(Vector2 velocity)
    {
        velocity.x += _FowardAcceleration * Time.deltaTime;
        _Gravity += _UpAcceleration * Time.deltaTime;
        _UpForce += _UpAcceleration * Time.deltaTime;
        _MaxGravity += _MaxVelocityAcceleration * Time.deltaTime;
        return velocity;
    }
}
