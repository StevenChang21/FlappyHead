using UnityEngine;
using UnityEngine.SceneManagement;

public class DedPopupPanel : MonoBehaviour
{
    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
