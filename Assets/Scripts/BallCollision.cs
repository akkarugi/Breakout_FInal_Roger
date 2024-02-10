using UnityEngine;

public class BallCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Rebote con paredes
            BounceOffWall();
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            // Rebote con la pala
            BounceOffPaddle(collision.contacts[0].point, collision.collider.bounds.size.x);
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            // Rebote con bloques
            BounceOffBlock(collision.contacts[0].point, collision.collider.bounds.size);
            Destroy(collision.gameObject);
        }
    }

    void BounceOffWall()
    {
        // Rebote simple
        GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(GetComponent<Rigidbody2D>().velocity, Vector2.right);
    }

    void BounceOffPaddle(Vector2 hitPoint, float paddleWidth)
    {
        // Calcular dirección basada en dónde golpea la pala
        float relativeHitPoint = (transform.position.x - hitPoint.x) / paddleWidth;
        Vector2 direction = new Vector2(relativeHitPoint, 1).normalized;

        // Aplicar el rebote
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void BounceOffBlock(Vector2 hitPoint, Vector2 blockSize)
    {
        // Calcular dirección basada en dónde golpea el bloque
        float relativeHitPoint = (transform.position.x - hitPoint.x) / blockSize.x;
        Vector2 direction = new Vector2(relativeHitPoint, 1).normalized;

        // Aplicar el rebote
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
