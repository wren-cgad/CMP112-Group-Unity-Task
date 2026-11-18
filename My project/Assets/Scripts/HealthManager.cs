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
            // handle death here
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Heal(int healthNumber)
    {   
        if (currentHealth + healthNumber < maxHealth){
            currentHealth += healthNumber;
        } else {
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
        targetFill = (float)currentHealth / maxHealth;
    }
}