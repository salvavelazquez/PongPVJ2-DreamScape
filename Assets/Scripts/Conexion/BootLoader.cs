using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    void Start()
    {
        // Espera un instante (evita errores de inicialización)
        SceneManager.LoadScene("Menu");
    }
}
