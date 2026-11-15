using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{
    private float speed = 2f; // speed in m/s
    private int enemyDamage = 10;
    private int enemyHealth = 3;
    public BoxCollider2D trigger;
    private Vector3 targetPosition;

    [Header("Flicker")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float flickerDuration = 0.2f;
    [SerializeField] private float flickerInterval = 0.05f;
    private Coroutine flickerRoutine;

    private void Start()
    {
        targetPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * 1000;
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
        if (collision.TryGetComponent<HealthManager>(out var health))
        {
            health.TakeDamage(enemyDamage);
            Destroy(gameObject);
        }
        if (collision.TryGetComponent<bulletDamage>(out var bullet))
        {
            TakeDamage(bullet.damage);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            return; // no point flickering something that's being destroyed
        }

        // restart the flicker if we get hit again mid-flicker
        if (flickerRoutine != null)
            StopCoroutine(flickerRoutine);
        flickerRoutine = StartCoroutine(Flicker());
    }

    private IEnumerator Flicker() {
    Color original = spriteRenderer.color;
    Color flash = Color.red; // flicker red when taking damage

    float elapsed = 0f;
    bool flashed = false;
    while (elapsed < flickerDuration)
    {
        flashed = !flashed;
        spriteRenderer.color = flashed ? flash : original;
        yield return new WaitForSeconds(flickerInterval);
        elapsed += flickerInterval;
    }
    spriteRenderer.color = original;
    flickerRoutine = null;
}
}