using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _offset;

    void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x, transform.position.y, _offset.z);
    }
}
