using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mirror.Examples.Pong
{
    public class GameManagerNetwork : NetworkBehaviour
    {
        public static GameManagerNetwork instance;

        [SyncVar] public int scoreLeft;
        [SyncVar] public int scoreRight;

        [SyncVar] public float timeRemaining = 60f;

        void Awake()
        {
            instance = this;
        }

        void Update()
        {
            if (!isServer) return;

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                EndMatch();
            }
        }

        [Server]
        public void AddScore(bool leftPlayer)
        {
            if (leftPlayer) scoreLeft++;
            else scoreRight++;
        }

        [Server]
        void EndMatch()
        {
            string winner;

            if (scoreLeft > scoreRight)
                winner = "¡Ganó Player 1 (Azul)!";
            else if (scoreRight > scoreLeft)
                winner = "¡Ganó Player 2 (Naranja)!";
            else
                winner = "¡Empate!";

            RpcEndGame(winner);
        }

        [ClientRpc]
        void RpcEndGame(string message)
        {
            WinnerHolder.winner = message;
            SceneManager.LoadScene("GameOver");
        }
    }
}
