using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false;

    public UnityEvent<float> onHealthChanged; // vida normalizada (0 a 1)
    public UnityEvent onDeath;

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;
    public bool IsDead => isDead;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        onHealthChanged?.Invoke(currentHealth / maxHealth);
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        currentHealth = Mathf.Max(currentHealth - amount, 0f);
        onHealthChanged?.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0f)
            Die();
    }

    public void Heal(float amount)
    {
        if (isDead)
            return;

        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        onHealthChanged?.Invoke(currentHealth / maxHealth);
    }

    private void Die()
    {
        isDead = true;
        onDeath?.Invoke();
    }
}