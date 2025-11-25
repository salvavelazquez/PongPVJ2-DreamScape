public class MoveDownCommand : ICommand
{
    private readonly PaddleController paddle;

    public MoveDownCommand(PaddleController paddle)
    {
        this.paddle = paddle;
    }

    public void Execute()
    {
        paddle.Move(-1f);
    }
}
