using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSalas : MonoBehaviour
{
    public static string modoJuego = "";

    public void SimpleOffline()
    {
        modoJuego = "offline";
        SceneManager.LoadScene("LevelOffline");
    }

    public void MultiplayerSimple()
    {
        modoJuego = "onlineSimple";
        SceneManager.LoadScene("MenuOnline");
    }

    public void MultiplayerHardcore()
    {
        modoJuego = "onlineHardcore";
        SceneManager.LoadScene("MenuOnline");
    }

    public void Volver()
    {
        SceneManager.LoadScene("Menu");
    }
}
