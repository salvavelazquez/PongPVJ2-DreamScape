using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using TMPro;

public class MenuClientIP : MonoBehaviour
{
    public TMP_InputField ipInput;

    public void Conectar()
    {
        if (string.IsNullOrEmpty(ipInput.text))
            return;

        NetworkManager.singleton.networkAddress = ipInput.text;
        NetworkManager.singleton.StartClient();

        // Cuando el cliente se conecta, cargamos la escena definida por el modo seleccionado
        SceneManager.LoadScene(GameModeSelection.CurrentMode.SceneName);
    }

    public void Volver()
    {
        SceneManager.LoadScene("MenuOnline");
    }
}
