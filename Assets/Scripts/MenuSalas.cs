using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSalas : MonoBehaviour
{
    public void SimpleOffline()
    {
        GameModeSelection.Select(new OfflineMode());
        SceneManager.LoadScene(GameModeSelection.CurrentMode.SceneName);
    }

    public void MultiplayerSimple()
    {
        GameModeSelection.Select(new OnlineSimpleMode());
        SceneManager.LoadScene("MenuOnline");
    }

    public void MultiplayerHardcore()
    {
        GameModeSelection.Select(new OnlineHardcoreMode());
        SceneManager.LoadScene("MenuOnline");
    }

    public void Volver()
    {
        SceneManager.LoadScene("Menu");
    }
}
