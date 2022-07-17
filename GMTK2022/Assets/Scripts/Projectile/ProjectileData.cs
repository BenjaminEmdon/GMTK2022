using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Projectiles/Generic Projectile", fileName = "New Projectile")]
public class ProjectileData : ScriptableObject
{
    public GameObject prefab;
    public int damage = 1;
    public int healAmount = 1;
    public float speed = 10.0f;
    public float lifespan = 5.0f;
    public CollisionInfo[] collisionInfo;

    [System.Serializable]
    public struct CollisionInfo
    {
        public LayerMask layerMask;
        public ActionsOnCollision actions;
    }

    [System.Flags]
    public enum ActionsOnCollision
    {
        None = 0,
        Damage = 1,
        Kill = 1 << 1,
        Heal = 1 << 2,
        HealMax = 1 << 3,
        DisableSelf = 1 << 4,
    }

    // Constructor
    public ProjectileData(GameObject _prefab, int _damage, float _speed, float _lifespan, CollisionInfo[] _collisionInfo)
    {
        prefab = _prefab;
        damage = _damage;
        speed = _speed;
        lifespan = _lifespan;
        collisionInfo = _collisionInfo;
    }
}
