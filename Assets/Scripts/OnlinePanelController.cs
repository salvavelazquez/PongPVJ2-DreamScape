using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OnlinePanelController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject panelOnline;
    public TMP_InputField inputIP;

    public void Host()
    {
        Debug.Log("HOST iniciado");
        NetworkManager.singleton.StartHost();
        panelOnline.SetActive(false);
    }

    public void Join()
    {
        string ip = inputIP.text;

        if (string.IsNullOrEmpty(ip))
            ip = "localhost";

        Debug.Log("CLIENT conectando a " + ip);

        NetworkManager.singleton.networkAddress = ip;
        NetworkManager.singleton.StartClient();

        panelOnline.SetActive(false);
    }

    public void VolverASalas()
    {
        SceneManager.LoadScene("MenuSalas");
    }
}
