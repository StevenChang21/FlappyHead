using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _GameOverUI;
    public static int HighScore;

    void Awake()
    {
        SaveManager.Load();
    }

    void OnDisable()
    {
        SaveManager.Save();
        Debug.Log("Saved!");
    }

    private void OnPlayerDied()
    {
        _GameOverUI.SetActive(true);
    }
}
