using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    void Start()
    {
        // Si el modo actual es Offline, usamos winnerMessage del GameManager local
        if (GameModeSelection.CurrentMode is OfflineMode)
        {
            winnerText.text = GameManager.instance.winnerMessage;
        }
        else
        {
            // Si es online, el mensaje viene desde WinnerHolder
            winnerText.text = WinnerHolder.winner;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        // Volvemos a cargar la escena del GameMode actual
        if (GameModeSelection.CurrentMode != null)
        {
            SceneManager.LoadScene(GameModeSelection.CurrentMode.SceneName);
        }
        else
        {
            // Fallback por seguridad
            SceneManager.LoadScene("Level1");
        }
    }
}
