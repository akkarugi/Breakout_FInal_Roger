using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        InitializeBall();
    }

    void InitializeBall()
    {
        transform.position = Vector2.zero;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = randomDirection * speed;
    }
}
