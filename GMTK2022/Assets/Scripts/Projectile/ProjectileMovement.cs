using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour, IPooledObject
{
    [Header("Declarations")]
    [SerializeField]
    private Rigidbody rb;

    protected int damage;
    protected Vector3 dir = Vector3.zero;
    protected float speed;
    protected float lifespan;

    // basically a constructor which i think are p neat
    // fuck you unity for not being able to use constructors on a monobehaviour >:(
    public virtual void Initialise(int _damage, Vector3 _dir, float _speed, float _lifespan)
    {
        damage = _damage;
        dir = _dir;
        speed = _speed;
        lifespan = _lifespan;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Death();
    }

    public virtual void OnObjectSpawn()
    {
        rb.velocity = dir * speed * Time.fixedDeltaTime;
    }

    protected virtual IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(lifespan);
        OnLifetimeEnd();
    }

    protected virtual void OnLifetimeEnd()
    {
        Death();
    }

    public virtual void Death()
    {
        gameObject.SetActive(false);
    }
}
