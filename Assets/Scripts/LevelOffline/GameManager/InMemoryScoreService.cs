public class InMemoryScoreService : IScoreService
{
    private int scoreP1;
    private int scoreP2;

    public int ScoreP1 => scoreP1;
    public int ScoreP2 => scoreP2;

    public void AddPoint(bool player1)
    {
        if (player1) scoreP1++;
        else scoreP2++;
    }

    public void ResetScores()
    {
        scoreP1 = 0;
        scoreP2 = 0;
    }
}
