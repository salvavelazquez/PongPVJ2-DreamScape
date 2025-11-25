using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 8f;
    public float limiteSuperior = 1f;
    public float limiteInferior = -1f;

    private float currentMove;

    public void Move(float direction)
    {
        currentMove = direction;
    }

    private void Update()
    {
        Vector3 movement = Vector2.up * currentMove * speed * Time.deltaTime;
        transform.Translate(movement);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, limiteInferior, limiteSuperior);
        transform.position = pos;
    }
}
