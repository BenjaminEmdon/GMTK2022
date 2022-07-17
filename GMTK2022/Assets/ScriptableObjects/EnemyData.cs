using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Enemy/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public EEnemyAttacks.enemyAttacks[] enemyAttackList;
}
