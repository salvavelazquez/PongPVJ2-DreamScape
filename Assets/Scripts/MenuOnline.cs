using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class MenuOnline : MonoBehaviour
{
    public void Host()
    {
        NetworkManager.singleton.StartHost();

        if (MenuSalas.modoJuego == "onlineSimple")
            NetworkManager.singleton.ServerChangeScene("Level1");

        if (MenuSalas.modoJuego == "onlineHardcore")
            NetworkManager.singleton.ServerChangeScene("Level2");
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
