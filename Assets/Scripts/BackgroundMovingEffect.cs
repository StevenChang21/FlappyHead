using UnityEngine;

public class BackgroundMovingEffect : MonoBehaviour
{
    [SerializeField] private float _MovingSpeed;
    private float _offset;
    private Material _Mat;

    void Start()
    {
        _Mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        _offset += (Time.deltaTime * _MovingSpeed) / 10f;
        _Mat.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
    }
}
