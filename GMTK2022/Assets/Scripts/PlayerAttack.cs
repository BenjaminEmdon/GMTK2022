using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   
    public Material[] currentAttackTextures;
    public EPlayerAttacks.Attacks[] currentAttacks;

    public PlayerData playerDice;
    // Start is called before the first frame update
    void Start()
    {
        currentAttacks = playerDice.attackList;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

   
}