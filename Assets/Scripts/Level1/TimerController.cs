using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public float tiempoRestante = 60f; // 1 minuto
    public bool tiempoCorriendo = true;

    public TextMeshProUGUI timerText;

    void Update()
    {
        if (tiempoCorriendo)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
                UpdateTimerUI(tiempoRestante);
            }
            else
            {
                tiempoRestante = 0;
                tiempoCorriendo = false;
                Finalized();
            }
        }
    }

    void UpdateTimerUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Finalized()
    {
        int p1 = GameManager.instance.scoreP1;
        int p2 = GameManager.instance.scoreP2;

        if (p1 > p2)
        {
            GameManager.instance.winnerMessage = "¡Ganó el Player 1 (Naranja)!";
        }
        else if (p2 > p1)
        {
            GameManager.instance.winnerMessage = "¡Ganó el Player 2 (Azul)!";
        }
        else
        {
            GameManager.instance.winnerMessage = "¡Empate!";
        }

        SceneManager.LoadScene("GameOver");
    }
}
