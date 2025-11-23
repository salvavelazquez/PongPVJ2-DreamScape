using UnityEngine;
using Mirror.Examples.Pong;

public class Rango : MonoBehaviour
{
    public bool esParedIzquierda; // true = LeftGoal, false = RightGoal

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Ball")) return;

        // SOLO sumar punto si la pelota tocó un GOAL real
        if (esParedIzquierda)
        {
            // pelota llegó al lado izquierdo → punto para Player 2 (derecha)
            GameManagerNetwork.instance.AddScore(false);
        }
        else
        {
            // pelota llegó al lado derecho → punto para Player 1 (izquierda)
            GameManagerNetwork.instance.AddScore(true);
        }
    }
}
