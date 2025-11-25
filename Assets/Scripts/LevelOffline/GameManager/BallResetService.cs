using UnityEngine;

public class BallResetService : MonoBehaviour, IBallResetService
{
    [SerializeField] private BallController ball;

    private void Awake()
    {
        if (ball == null)
            ball = FindObjectOfType<BallController>();
    }

    public void ResetBall()
    {
        ball.ResetToCenterAndLaunch();
    }
}
