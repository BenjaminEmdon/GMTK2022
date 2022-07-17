using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Projectiles/Generic Projectile", fileName = "New Projectile")]
public class ProjectileData : ScriptableObject
{
    public GameObject prefab;
    public int damage = 1;
    public float speed = 10.0f;
    public float lifespan = 5.0f;
    public LayerMask collisionLayers = new LayerMask();

    // Constructor
    public ProjectileData(GameObject _prefab, int _damage, float _speed, float _lifespan, LayerMask _collisionLayers)
    {
        prefab = _prefab;
        damage = _damage;
        speed = _speed;
        lifespan = _lifespan;
        collisionLayers = _collisionLayers;
    }
}
