using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Enemy/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public int maxHealth = 10;
    public EEnemyAttacks.enemyAttacks[] enemyAttackList;

    public EnemyData(int _maxHealth, EEnemyAttacks.enemyAttacks[] _enemyAttackList)
    {
        maxHealth = _maxHealth;
        enemyAttackList = _enemyAttackList;
    }
}
