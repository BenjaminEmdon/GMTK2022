using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/PlayerData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public int maxHealth = 10;
    public EPlayerAttacks.Attacks[] attackList;
    public int nextLevel = 1;

    public PlayerData(int _maxHealth, EPlayerAttacks.Attacks[] _attackList, int _nextLevel)
    {
        maxHealth = _maxHealth;
        attackList = _attackList;
        nextLevel = _nextLevel;
    }
}