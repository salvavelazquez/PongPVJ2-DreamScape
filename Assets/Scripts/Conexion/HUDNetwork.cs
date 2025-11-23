using UnityEngine;
using TMPro;

public class HUDNetwork : MonoBehaviour
{
    public TextMeshProUGUI leftScore;
    public TextMeshProUGUI rightScore;
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (Mirror.Examples.Pong.GameManagerNetwork.instance == null)
            return;

        var gm = Mirror.Examples.Pong.GameManagerNetwork.instance;

        leftScore.text = gm.scoreLeft.ToString();
        rightScore.text = gm.scoreRight.ToString();

        float t = gm.timeRemaining;
        timerText.text = string.Format("{0:00}:{1:00}",
            Mathf.FloorToInt(t / 60),
            Mathf.FloorToInt(t % 60));
    }
}
