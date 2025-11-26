using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoaderAutoLoad : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Menu");
    }
}
