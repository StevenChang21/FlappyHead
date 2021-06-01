using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public abstract Vector2 Move(bool move_up, Vector2 velocity);
}
