using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public EPlayerAttacks.Attacks[] currentAttackList;
    private int i=0;
    private EPlayerAttacks.Attacks[] newAttacksOffered;
    private EPlayerAttacks.Attacks newAttack;
    private EPlayerAttacks.Attacks attackRemoved;
    public PlayerData playerDice;
    [SerializeField] private GameObject[] currentDice;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAttackList = playerDice.attackList;

        foreach (GameObject Dice in currentDice)
        {
            Dice.GetComponent<UIDiceInfo>().attackType = currentAttackList[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
