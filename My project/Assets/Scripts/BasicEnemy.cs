using Unity.VisualScripting;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private float speed = 10f; // speed in m/s

    public BoxCollider2D trigger;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0f), 0f) * 1000; // ensure always off screen
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

}
