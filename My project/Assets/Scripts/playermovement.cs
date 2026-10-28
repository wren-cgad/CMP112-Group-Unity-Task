using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public const float SPEED = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.linearVelocity = -transform.right * SPEED;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.linearVelocity = transform.right * SPEED;
        }
    }

}
