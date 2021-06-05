using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    [SerializeField] Button _PauseButton;
    [SerializeField] Button _ResumeButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                _ResumeButton.onClick?.Invoke();
            }
            else
            {
                _PauseButton.onClick?.Invoke();
            }
        }
    }

    public void Resume() => Time.timeScale = 1;

    public void Pause() => StartCoroutine(WaitUIEffectsEnd(() => Time.timeScale = 0));

    private System.Collections.IEnumerator WaitUIEffectsEnd(System.Action action)
    {
        yield return new WaitForSeconds(0.5f);
        action?.Invoke();
    }
}
