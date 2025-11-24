using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    void Start()
    {

            if (MenuSalas.modoJuego == "offline")
                winnerText.text = GameManager.instance.winnerMessage;
            else
                winnerText.text = WinnerHolder.winner;

    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
    }
}
