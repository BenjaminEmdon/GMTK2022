using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private Rigidbody rb;

    [HideInInspector]
    public float lifespan;
    [HideInInspector]
    public Vector3 dir = Vector3.zero;
    [HideInInspector]
    public float speed;

    protected virtual void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
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
