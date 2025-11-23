using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using TMPro;

public class MenuClientIP : MonoBehaviour
{
    public TMP_InputField ipInput;

    public void Conectar()
    {
        if (string.IsNullOrEmpty(ipInput.text)) return;

        NetworkManager.singleton.networkAddress = ipInput.text;
        NetworkManager.singleton.StartClient();

        if (MenuSalas.modoJuego == "onlineSimple")
            SceneManager.LoadScene("Level1");

        if (MenuSalas.modoJuego == "onlineHardcore")
            SceneManager.LoadScene("Level2");
    }

    public void Volver()
    {
        SceneManager.LoadScene("MenuOnline");
    }
}
