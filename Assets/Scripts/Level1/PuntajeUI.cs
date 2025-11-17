using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreP1Text;
    public TextMeshProUGUI scoreP2Text;

    void Update()
    {
        scoreP1Text.text = GameManager.instance.scoreP1.ToString();
        scoreP2Text.text = GameManager.instance.scoreP2.ToString();
    }
}
