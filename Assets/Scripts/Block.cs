using UnityEngine;

public class Block : MonoBehaviour
{
    public int scoreValue = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.AddScore(scoreValue);
        }
    }
}
