using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Mirror;

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
        // Si estoy en modo OFFLINE voy directo al menú
        if (GameModeSelection.CurrentMode is OfflineMode)
        {
            GameManager.instance.ResetScores();
            SceneManager.LoadScene("Menu");
            return;
        }

        // Si está hosteando (server+client)
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        // Si es solo cliente
        else if (NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopClient();
        }
        // Si por algún motivo es solo server
        else if (NetworkServer.active)
        {
            NetworkManager.singleton.StopServer();
        }

        // Apagar el transport
        if (NetworkManager.singleton != null)
            NetworkManager.singleton.transport.Shutdown();

        // Destruir el network manager del DontDestroyOnLoad
        if (NetworkManager.singleton != null)
            Destroy(NetworkManager.singleton.gameObject);

        // Volver al menú
        SceneManager.LoadScene("Menu");
    }

   
}
