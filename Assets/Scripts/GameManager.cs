using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int HighScore;

    void Awake()
    {
        SaveManager.Load();
    }

    void OnDestroy()
    {
        SaveManager.Save();
    }
}
