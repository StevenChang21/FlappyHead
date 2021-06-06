using UnityEngine;

public class BackgroundMovingEffect : MonoBehaviour
{
    [SerializeField] private Vector2 _MovingVelocity;
    private Vector2 _offset;
    private Material _Mat;

    void Start()
    {
        _Mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        _offset += (Time.deltaTime * _MovingVelocity) / 10f;
        _Mat.SetTextureOffset("_MainTex", _offset);
    }
}
