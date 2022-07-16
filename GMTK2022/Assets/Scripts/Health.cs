using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected int health = 10;
    public int GetHealth() { return health; }
    public virtual void SetHealth(int value)
    {
        health = value;
    }

    [SerializeField]
    protected int maxHealth = 10;
    public int GetMaxHealth() { return maxHealth; }
    public virtual void SetMaxHealth(int value)
    {
        maxHealth = value;
    }

    protected virtual void Awake()
    {
        SetHealth(maxHealth);
    }

    public virtual void TakeDamage(int amount)
    {
        SetHealth(health - amount);
    }

    public virtual void Heal(int amount)
    {
        SetHealth(health + amount);
    }
}