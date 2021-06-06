using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public abstract Vector2 Move(bool move_up, bool move_down, Vector2 velocity);
}
