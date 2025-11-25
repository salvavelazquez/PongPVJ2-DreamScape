using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class MenuOnline : MonoBehaviour
{
    public void Host()
    {
        NetworkManager.singleton.StartHost();

        // Cargar la escena definida por el modo actual
        NetworkManager.singleton.ServerChangeScene(GameModeSelection.CurrentMode.SceneName);
    }

    public void Client()
    {
        SceneManager.LoadScene("MenuClientIP");
    }

    public void Volver()
    {
        SceneManager.LoadScene("MenuSalas");
    }
}
