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
    protected LayerMask collisionLayers;

    // basically a constructor which i think are p neat
    // fuck you unity for not being able to use constructors on a monobehaviour >:(
    public virtual void Initialise(int _damage, Vector3 _dir, float _speed, float _lifespan, LayerMask _collisionLayers)
    {
        damage = _damage;
        dir = _dir;
        speed = _speed;
        lifespan = _lifespan;
        collisionLayers = _collisionLayers;

        rb.velocity = dir * speed * Time.fixedDeltaTime * 100.0f;
        StartCoroutine(DeathTimer());
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // Check if other's layer matches one in our layer mask, then invoke Death if so
        if ((collisionLayers.value & (1 << other.gameObject.layer)) > 0)
        {
            Death();
        }
    }

    public virtual void OnObjectSpawn()
    {

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
