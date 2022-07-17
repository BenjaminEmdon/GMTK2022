using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    protected int health = 10;
    public int GetHealth() { return health; }

    protected int maxHealth = 10;
    public int GetMaxHealth() { return maxHealth; }

    private bool isAlive = true;
    public bool GetIsAlive() { return isAlive; }

    enum ActionOnDeath
    {
        None,
        Disable,
        Destroy,
        DestroyImmediate,
    }

    [SerializeField]
    private ActionOnDeath actionOnDeath = ActionOnDeath.None;

    [Header("Events")]
    public UnityEvent<int> onTakeDamage;                // Passes damage taken
    public UnityEvent<int> onInjured;                   // Take damage but not dead. Passes damage taken.
    public UnityEvent<int> onHeal;                      // Passes health healed
    public UnityEvent<int> onHealthValueChanged;        // Passes new health value
    public UnityEvent<int> onMaxHealthValueChanged;     // Passes new max health value
    public UnityEvent onDeath;

    protected virtual void Awake()
    {
        SetHealth(maxHealth);
    }

    public virtual void SetHealth(int value)
    {
        health = Mathf.Clamp(value, 0, maxHealth);
        onHealthValueChanged.Invoke(health);

        if (health <= 0)
        {
            Death();
        }
        else if (!isAlive)
        {
            isAlive = true;
        }
    }

    public virtual void SetMaxHealth(int value)
    {
        maxHealth = value;
        onMaxHealthValueChanged.Invoke(maxHealth);

        // Clamp current health within new boundaries
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public virtual void TakeDamage(int amount)
    {
        SetHealth(health - amount);
        onTakeDamage.Invoke(amount);

        if (isAlive)
        {
            onInjured.Invoke(amount);
        }
    }

    public virtual void Heal(int amount)
    {
        int oldHealth = health;             // used to correctly calculate health healed if health would've exceeded max health
        SetHealth(health + amount);         // add health healed to our current health
        onHeal.Invoke(health - oldHealth);
    }

    public virtual void Kill()
    {
        TakeDamage(health);
    }

    protected virtual void Death()
    {
        isAlive = false;
        onDeath.Invoke();

        switch (actionOnDeath)
        {
            case ActionOnDeath.None:
                break;
            case ActionOnDeath.Disable:
                gameObject.SetActive(false);
                break;
            case ActionOnDeath.Destroy:
                Destroy(gameObject);
                break;
            case ActionOnDeath.DestroyImmediate:
                DestroyImmediate(gameObject);
                break;
            default:
                break;
        }
    }
}