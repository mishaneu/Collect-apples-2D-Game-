using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteMenu;
    public TextMeshProUGUI txt1;
    public Image img1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Apple.appleCount == 0)
        {
            levelCompleteMenu.SetActive(true);
            Time.timeScale = 0f;
            txt1.gameObject.SetActive(false);
            img1.gameObject.SetActive(false);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}