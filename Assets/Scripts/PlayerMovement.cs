using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxX = 2.5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 currentPosition = transform.position;
        currentPosition.x += horizontalInput * moveSpeed * Time.deltaTime;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -maxX, maxX);
        transform.position = currentPosition;
    }
}
