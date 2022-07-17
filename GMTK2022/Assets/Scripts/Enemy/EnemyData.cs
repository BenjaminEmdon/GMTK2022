using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Enemy/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Health Settings")]
    [Tooltip("Maximum health this enemy has.")]
    public int maxHealth = 10;

    [Header("Face Ability Settings")]
    public EEnemyAttacks.enemyAttacks[] enemyAttackList;

    [Header("Movement Settings")]
    [Tooltip("The magnitude at which this enemy should fling itself. Higher = more powerful flinging.")]
    public float flingMagnitude = 1.0f;
    [Tooltip("This force is added to the fling force to offset it.")]
    public Vector3 flingDirOffset = new Vector3(0.0f, 0.5f, 1.0f);
    [Tooltip("The magnitude at which the torque is applied when flinging. Torque is what causes it to spin mid-air.")]
    public float flingTorqueMagnitude = 20.0f;

    // Constructor
    public EnemyData(int _maxHealth, EEnemyAttacks.enemyAttacks[] _enemyAttackList, float _flingMagnitude, Vector3 _flingDirOffset)
    {
        maxHealth = _maxHealth;
        enemyAttackList = _enemyAttackList;
        flingMagnitude = _flingMagnitude;
        flingDirOffset = _flingDirOffset;
    }
}
