using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int scoreP1;
    public int scoreP2;
    public string winnerMessage;

    void Awake()
    {
        instance = this;
    }

    public void ScorePoint(bool player1)
    {
        if (player1) scoreP1++;
        else scoreP2++;

        // Reiniciar pelota
        FindObjectOfType<BallController>().transform.position = Vector2.zero;
    }
}
