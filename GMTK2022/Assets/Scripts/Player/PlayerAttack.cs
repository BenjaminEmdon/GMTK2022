using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Material[] currentAttackTextures;
    public EPlayerAttacks.Attacks[] currentAttacks;
    public PlayerData data;

    // Start is called before the first frame update
    void Start()
    {
        currentAttacks = data.attackList;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}