using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Apple : MonoBehaviour
{
    public TextMeshProUGUI appleCountText;
    public static int appleCount = 3;
    public Image AppleImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            appleCount--;
            if (appleCount > 0)
            {
                appleCountText.text = "Осталось: " + appleCount.ToString();
            }
            else
            {
                appleCountText.text = "Найдите выход!";
                AppleImage.gameObject.SetActive(false);

            }
            Destroy(collision.gameObject);
        }
    }
}