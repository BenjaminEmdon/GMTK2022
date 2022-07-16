using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public EPlayerAttacks.Attacks[] currentAttackList;
    private int i=0;
    private EPlayerAttacks.Attacks[] newAttacksOffered;
    private int attackToOffer;
    private EPlayerAttacks.Attacks newAttack;
    private EPlayerAttacks.Attacks attackRemoved;
    public PlayerData playerDice;
    [SerializeField] private GameObject[] currentDice;
    [SerializeField] private Sprite[] DiceSprites;
    [SerializeField] private GameObject[] NewDice;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject newDice in NewDice)
        {
            
            attackToOffer = Random.Range(0, 6);
            
            switch(attackToOffer)
            {
                case 0: newDice.transform.parent.GetComponent<Image>().sprite = DiceSprites[0];
                        newDice.GetComponent<UINewDiceInfo>().attackType = EPlayerAttacks.Attacks.Hit;
                        break;
                case 1: newDice.transform.parent.GetComponent<Image>().sprite = DiceSprites[1];
                        newDice.GetComponent<UINewDiceInfo>().attackType = EPlayerAttacks.Attacks.DoubleHit;
                        break;
                case 2: newDice.transform.parent.GetComponent<Image>().sprite = DiceSprites[2];
                        newDice.GetComponent<UINewDiceInfo>().attackType = EPlayerAttacks.Attacks.TripleHit;
                        break;
                case 3: newDice.transform.parent.GetComponent<Image>().sprite = DiceSprites[3];
                        newDice.GetComponent<UINewDiceInfo>().attackType = EPlayerAttacks.Attacks.Heal;
                        break;
                case 4: newDice.transform.parent.GetComponent<Image>().sprite = DiceSprites[4];
                        newDice.GetComponent<UINewDiceInfo>().attackType = EPlayerAttacks.Attacks.HealTwice;
                        break;
                case 5: newDice.transform.parent.GetComponent<Image>().sprite = DiceSprites[5];
                        newDice.GetComponent<UINewDiceInfo>().attackType = EPlayerAttacks.Attacks.HealThrice;
                        break;
                case 6: newDice.transform.parent.GetComponent<Image>().sprite = DiceSprites[6];
                        newDice.GetComponent<UINewDiceInfo>().attackType = EPlayerAttacks.Attacks.Bomb;
                        break;
                default: print("failed");
                break;
            }
        }
        
        currentAttackList = playerDice.attackList;

        foreach (GameObject Dice in currentDice)
        {
            Dice.GetComponent<UIDiceInfo>().attackType = currentAttackList[i];
           
           switch (currentAttackList[i])
           {
                case EPlayerAttacks.Attacks.Hit:
                     Dice.GetComponent<Image>().sprite = DiceSprites[0];
                     break;
                case EPlayerAttacks.Attacks.DoubleHit:
                     Dice.GetComponent<Image>().sprite = DiceSprites[1];
                     break;
                     case EPlayerAttacks.Attacks.TripleHit:
                     Dice.GetComponent<Image>().sprite = DiceSprites[2];
                     break;
                     case EPlayerAttacks.Attacks.Heal:
                     Dice.GetComponent<Image>().sprite = DiceSprites[3];
                     break;
                     case EPlayerAttacks.Attacks.HealTwice:
                     Dice.GetComponent<Image>().sprite = DiceSprites[4];
                     break;
                     case EPlayerAttacks.Attacks.HealThrice:
                     Dice.GetComponent<Image>().sprite = DiceSprites[5];
                     break;
                     case EPlayerAttacks.Attacks.Bomb:
                     Dice.GetComponent<Image>().sprite = DiceSprites[6];
                     break;
                     case EPlayerAttacks.Attacks.Miss:
                     Dice.GetComponent<Image>().sprite = DiceSprites[7];
                     break;
                default: print("failed");
                         break;
           }
            i++;

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
