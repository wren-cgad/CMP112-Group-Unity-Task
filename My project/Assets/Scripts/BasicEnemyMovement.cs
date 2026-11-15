using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    private float speed = 1f; // speed in m/s
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * 1000;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
