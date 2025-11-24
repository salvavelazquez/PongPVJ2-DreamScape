using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LanzamientoPelota();
    }

    void LanzamientoPelota()
    {
        float x = Random.value < 0.5f ? -1 : 1;
        float y = Random.Range(-1f, 1f);

        rb.linearVelocity = new Vector2(x, y).normalized * speed;
    }
}
