using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 8f;
    public bool esPlayer2 = true;

    // LÍMITES VERTICALES
    public float limiteSuperior = 1f;
    public float limiteInferior = -1f;

    void Update()
    {
        float move = 0;

        if (esPlayer2)
        {
            if (Input.GetKey(KeyCode.W)) move = 1;
            if (Input.GetKey(KeyCode.S)) move = -1;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) move = 1;
            if (Input.GetKey(KeyCode.DownArrow)) move = -1;
        }

        transform.Translate(Vector2.up * move * speed * Time.deltaTime);

        // SE APLICA LOS LIMITES
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, limiteInferior, limiteSuperior);
        transform.position = pos;
    }
}
