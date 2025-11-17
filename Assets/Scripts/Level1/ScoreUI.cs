using UnityEngine;
using TMPro;

public class PuntajeUI : MonoBehaviour
{
    public TextMeshProUGUI scoreP2;
    public TextMeshProUGUI scoreP1;

    void Update()
    {
        scoreP1.text = GameManager.instance.scoreP1.ToString();
        scoreP2.text = GameManager.instance.scoreP2.ToString();
    }
}
