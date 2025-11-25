using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchRandom();
    }

    public void ResetToCenterAndLaunch()
    {
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
        LaunchRandom();
    }

    private void LaunchRandom()
    {
        float x = Random.value < 0.5f ? -1 : 1;
        float y = Random.Range(-1f, 1f);

        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * speed;
    }
}
