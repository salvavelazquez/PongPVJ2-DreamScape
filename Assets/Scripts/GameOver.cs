using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    void Start()
    {
        winnerText.text = GameManager.instance.winnerMessage;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level1"); // o el nivel actual
    }
}
