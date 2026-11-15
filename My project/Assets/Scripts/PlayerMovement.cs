using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class playermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public const float SPEED = 5f;

    [Header("Circle Settings")]
    public int segments = 12;
    private LineRenderer lineRenderer; // allows you to set line resolution in editor

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.useWorldSpace = true;
        lineRenderer.loop = true;
        lineRenderer.positionCount = segments;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }

    void FixedUpdate()
    {
        if (transform.parent == null) return;

        Vector2 dirToParent = transform.parent.TransformDirection(-(Vector2)transform.localPosition).normalized;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
                // move towards parent
                
                rb.linearVelocity = dirToParent * SPEED;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            
            if (Vector2.Distance(transform.localPosition, transform.parent.localPosition) < 8)
            {
                // move away from parent

                rb.linearVelocity = -dirToParent * SPEED;
            } else
            {
                rb.linearVelocity = Vector2.zero;
            }
                print(Vector2.Distance(transform.localPosition, transform.parent.localPosition));
        }
    }

    void LateUpdate()
    {
        if (transform.parent == null) return;

        DrawCircle();
    }

    void DrawCircle()
    {
        // use the current distance from the parent as the radius
        float radius = Vector2.Distance(transform.position, transform.parent.position);
        Vector3 center = transform.parent.position;

        float angleStep = 360f / segments;

        for (int i = 0; i < segments; i++)
        {
            float angle = Mathf.Deg2Rad * (i * angleStep);
            float x = center.x + Mathf.Cos(angle) * radius;
            float y = center.y + Mathf.Sin(angle) * radius; // circle maths taken from stack overflow, but the implementation is my own

            lineRenderer.SetPosition(i, new Vector3(x, y, center.z));
        }
    }
}
