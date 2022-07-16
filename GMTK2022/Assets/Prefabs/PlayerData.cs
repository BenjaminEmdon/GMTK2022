using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Player/PlayerData", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{

    public EPlayerAttacks.Attacks[] attackList;
    
}
