using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int enemyDamage = 10;
    [SerializeField] private int enemyHealth = 3;
    public BoxCollider2D trigger;
    public AudioSource deathSound;

    [Header("Flicker")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float flickerDuration = 0.2f;
    [SerializeField] private float flickerInterval = 0.05f;
    private Coroutine flickerRoutine;

    private bool isDead = false; // prevents double-triggering death function

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return; // stop processing collisions if already dead

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
        if (isDead) return;
        enemyHealth -= damageAmount;
        
        StartCoroutine(DamageNoise());
        
        if (flickerRoutine != null)
            StopCoroutine(flickerRoutine); // restart the flicker if we get hit again mid-flicker
        flickerRoutine = StartCoroutine(Flicker());
    }

    private IEnumerator DamageNoise()
    {
        if (!isDead){
            // make sure it only plays while alive
            deathSound.PlayOneShot(deathSound.clip);  
        }
        if (enemyHealth <= 0) {
            isDead = true;
            // make sure it doesn't clip when dying
            yield return new WaitForSeconds(deathSound.clip.length);  
            Destroy(gameObject);
        }
    }
    private IEnumerator Flicker() 
    {
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
