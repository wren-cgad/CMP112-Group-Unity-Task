using UnityEngine;

public class Boidish : MonoBehaviour
{
    // adapted "seeker" state from this paper to unity c#
    // source: https://www.red3d.com/cwr/papers/1999/gdc99steer.pdf
    [SerializeField] private Transform player;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float maxSteerForce = 20f;

    private Vector2 velocity;

    private void Start()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null) player = playerObject.transform;
        }

        velocity = Random.insideUnitCircle * maxSpeed;
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        // steer toward the player (desired velocity minus current velocity)
        Vector2 toPlayer = (Vector2)(player.position - transform.position);
        Vector2 desired = toPlayer.normalized * maxSpeed;
        Vector2 steering = Vector2.ClampMagnitude(desired - velocity, maxSteerForce); // max steer force added to prevent weird wide swerves;

        velocity = velocity + steering * Time.deltaTime;
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }
}