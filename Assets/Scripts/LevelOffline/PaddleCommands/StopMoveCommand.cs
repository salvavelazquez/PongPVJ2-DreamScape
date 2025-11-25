public class StopMoveCommand : ICommand
{
    private readonly PaddleController paddle;

    public StopMoveCommand(PaddleController paddle)
    {
        this.paddle = paddle;
    }

    public void Execute()
    {
        paddle.Move(0f);
    }
}
