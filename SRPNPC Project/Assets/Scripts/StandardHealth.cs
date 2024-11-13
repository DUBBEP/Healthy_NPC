using System;
using UnityEngine;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;

    private int currentHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    public float CurrentHpPct
    {
        get { return (float)currentHealth / (float)startingHealth; }
    }

    private void Start()
    {
        currentHealth = startingHealth;
        OnHPPctChanged(CurrentHpPct);
    }



    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        currentHealth -= amount;

        OnHPPctChanged(CurrentHpPct);

        if (CurrentHpPct <= 0)
            Die();
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}