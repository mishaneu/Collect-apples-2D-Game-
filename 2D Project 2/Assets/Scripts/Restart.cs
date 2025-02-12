using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Apple.appleCount = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}