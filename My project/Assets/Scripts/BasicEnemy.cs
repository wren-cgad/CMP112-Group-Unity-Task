using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private  int enemyDamage = 10;
    [SerializeField] private  int enemyHealth = 3;
    public BoxCollider2D trigger;


    [Header("Flicker")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float flickerDuration = 0.2f;
    [SerializeField] private float flickerInterval = 0.05f;
    private Coroutine flickerRoutine;

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
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    spriteRenderer.color = original;
    flickerRoutine = null;
}
}