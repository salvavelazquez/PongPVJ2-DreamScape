using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private IScoreService scoreService;
    private IBallResetService ballResetService;

    public string winnerMessage { get; private set; }

    public int scoreP1 => scoreService.ScoreP1;
    public int scoreP2 => scoreService.ScoreP2;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        scoreService = new InMemoryScoreService();
    }

    private void Start()
    {
        ballResetService = FindObjectOfType<BallResetService>();
    }

    public void ScorePoint(bool player1)
    {
        scoreService.AddPoint(player1);
        ballResetService.ResetBall();
    }

    public void SetWinner()
    {
        if (scoreP1 > scoreP2)
            winnerMessage = "Ganó Player 1";
        else if (scoreP2 > scoreP1)
            winnerMessage = "Ganó Player 2";
        else
            winnerMessage = "Empate";
    }
}
