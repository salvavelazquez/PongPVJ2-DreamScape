public interface IScoreService
{
    int ScoreP1 { get; }
    int ScoreP2 { get; }

    void AddPoint(bool player1);
    void ResetScores();
}
