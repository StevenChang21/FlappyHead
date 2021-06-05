using UnityEngine;
using UnityEngine.Events;

public class LeanTweenMaster : MonoBehaviour
{
    [SerializeField] private LeanTweenType _LeanTweenType = LeanTweenType.notUsed;
    [SerializeField] private float _Duration = .5f;
    [SerializeField]
    private bool _PlayOnEnable, _PlayOnDisable;

    void OnEnable()
    {
        if (!_PlayOnEnable) { return; }
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, _Duration).setEase(_LeanTweenType);
    }

    public void PlayOnDisable()
    {
        if (!_PlayOnDisable) { return; }
        LeanTween.scale(gameObject, Vector3.zero, _Duration).setEase(_LeanTweenType).setOnComplete(() => gameObject.SetActive(false));
    }

    public void PlayOnDisableWithAction(UnityEvent action)
    {
        if (!_PlayOnDisable) { return; }
        LeanTween.scale(gameObject, Vector3.zero, _Duration).setEase(_LeanTweenType).setOnComplete(() =>
        {
            gameObject.SetActive(false);
            action?.Invoke();
        }
        );
    }
}
