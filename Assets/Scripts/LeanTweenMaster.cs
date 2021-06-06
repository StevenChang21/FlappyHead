using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LeanTweenMaster : MonoBehaviour
{
    [SerializeField] private GameObject[] _DisableUI;
    [SerializeField] private GameObject[] _EnableUI;
    [SerializeField] private LeanTweenType _LeanTweenType = LeanTweenType.notUsed;
    [SerializeField] private float _Duration = .5f;

    [SerializeField]
    private bool _PlayOnEnable, _PlayOnDisable;

    public void PlayOnDisable()
    {
        if (!_PlayOnDisable) { return; }
        foreach (var ui in _DisableUI)
        {
            if (TryGetComponent(out Button button))
            {
                button.interactable = false;
            }
            LeanTween.scale(ui, Vector3.zero, _Duration).setEase(_LeanTweenType).setOnComplete(() => ui.SetActive(false));
        }
    }

    public void PlayOnEnable()
    {
        if (!_PlayOnEnable) { return; }
        foreach (var ui in _EnableUI)
        {
            ui.SetActive(true);
            ui.transform.localScale = Vector3.zero;
            LeanTween.scale(ui, Vector3.one, _Duration).setEase(_LeanTweenType);
        }
    }
}
