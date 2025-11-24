using UnityEngine;

public class RangoLocal : MonoBehaviour
{
    public bool esParedIzquierda;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            GameManager.instance.ScorePoint(!esParedIzquierda);
        }
    }
}
