using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public Image healthBarFill;
    [SerializeField] private float smoothSpeed = 5f;

    private int currentHealth;
    private float targetFill;

    private void Awake()
    {
        ResetHealth();
    }

    private void Update()
    {
        // if healthBarFill is close enough, within a tiny margin, to target fill, don't lerp
        // (as lerping never quite reaches the value)
        if (!Mathf.Approximately(healthBarFill.fillAmount, targetFill))
        {
            healthBarFill.fillAmount = Mathf.Lerp(
                healthBarFill.fillAmount,
                targetFill,
                smoothSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damageNumber)
    {
        currentHealth -= damageNumber;
        UpdateTarget();

        if (currentHealth <= 0)
        {
             FindAnyObjectByType<RetryScreen>().setRetry();
            Destroy(gameObject);
        }
    }

    public void Heal(int healthNumber)
    {   
        // make sure health is always under or equal to max
        if (currentHealth + healthNumber < maxHealth){
            currentHealth += healthNumber;
        } else {
            // if health would go over, set it to max instead
            ResetHealth();
        }
            
        UpdateTarget();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        targetFill = 1f;
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        // updates the target fill for the lerp
        targetFill = (float)currentHealth / maxHealth;
    }
}