using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour, IPooledObject
{
    [Header("Declarations")]
    [SerializeField]
    private Rigidbody rb;

    protected Vector3 dir = Vector3.zero;
    protected ProjectileData data;

    // basically a constructor which i think are p neat
    // fuck you unity for not being able to use constructors on a monobehaviour >:(
    public virtual void Initialise(ProjectileData _projectileData, Vector3 _dir)
    {
        data = _projectileData;
        dir = _dir;

        rb.velocity = dir * data.speed * Time.fixedDeltaTime * 100.0f;
        StartCoroutine(DeathTimer());
    }

    public virtual void OnObjectSpawn()
    {

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < data.collisionInfo.Length; i++)
        {
            if ((data.collisionInfo[i].layerMask.value & (1 << other.gameObject.layer)) > 0)
            {
                Health health = other.GetComponent<Health>();

                if (health != null)
                {
                    // cringe
                    // basically a switch case but for an enum with flags
                    if (data.collisionInfo[i].actions.HasFlag(ProjectileData.ActionsOnCollision.Damage))
                        Damage(health, data.damage);
                    if (data.collisionInfo[i].actions.HasFlag(ProjectileData.ActionsOnCollision.Kill))
                        Kill(health);
                    if (data.collisionInfo[i].actions.HasFlag(ProjectileData.ActionsOnCollision.Heal))
                        Heal(health, data.healAmount);
                    if (data.collisionInfo[i].actions.HasFlag(ProjectileData.ActionsOnCollision.HealMax))
                        Heal(health, health.GetMaxHealth() - health.GetHealth());
                }

                if (data.collisionInfo[i].actions.HasFlag(ProjectileData.ActionsOnCollision.DisableSelf))
                    Death();
            }
        }
    }

    protected virtual void Damage(Health health, int amount)
    {
        health.TakeDamage(amount);
    }

    protected virtual void Kill(Health health)
    {
        health.Kill();
    }

    protected virtual void Heal(Health health, int amount)
    {
        health.Heal(amount);
    }

    public virtual void Death()
    {
        gameObject.SetActive(false);
    }

    protected virtual IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(data.lifespan);
        OnLifetimeEnd();
    }

    protected virtual void OnLifetimeEnd()
    {
        Death();
    }
}
