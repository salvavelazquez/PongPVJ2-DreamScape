using UnityEngine;

public class PaddleInputHandler : MonoBehaviour
{
    [SerializeField] private PaddleController paddle;
    [SerializeField] private bool esPlayer1 = true;

    private ICommand moveUpCommand;
    private ICommand moveDownCommand;
    private ICommand stopCommand;

    private void Awake()
    {
        if (paddle == null)
            paddle = GetComponent<PaddleController>();

        moveUpCommand = new MoveUpCommand(paddle);
        moveDownCommand = new MoveDownCommand(paddle);
        stopCommand = new StopMoveCommand(paddle);
    }

    private void Update()
    {
        ICommand command = stopCommand;

        if (esPlayer1)
        {
            if (Input.GetKey(KeyCode.W)) command = moveUpCommand;
            else if (Input.GetKey(KeyCode.S)) command = moveDownCommand;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) command = moveUpCommand;
            else if (Input.GetKey(KeyCode.DownArrow)) command = moveDownCommand;
        }

        command.Execute();
    }
}
