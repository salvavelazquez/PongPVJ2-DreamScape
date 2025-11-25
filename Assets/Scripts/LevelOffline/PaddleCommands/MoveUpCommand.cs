public class MoveUpCommand : ICommand
{
    private readonly PaddleController paddle;

    public MoveUpCommand(PaddleController paddle)
    {
        this.paddle = paddle;
    }

    public void Execute()
    {
        paddle.Move(1f);
    }
}
