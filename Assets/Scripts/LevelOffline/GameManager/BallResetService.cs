using UnityEngine;

public class BallResetService : MonoBehaviour, IBallResetService
{
    [SerializeField] private BallController ball;

    private void OnEnable()
    {
        if (ball == null)
            ball = Object.FindFirstObjectByType<BallController>();
    }

    public void ResetBall()
    {
        if (ball == null)
            ball = Object.FindFirstObjectByType<BallController>();

        ball.ResetToCenterAndLaunch();
    }
}
