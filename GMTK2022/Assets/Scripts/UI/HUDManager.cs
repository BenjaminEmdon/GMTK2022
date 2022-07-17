using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public GameObject BossRollSprite;
    public GameObject BossName;
    public GameObject PlayerRollSprite;
    public GameObject LevelManager;
    public Sprite[] diceRolls;
    public DiceUIDataBase spriteList;
    public PlayerDye playerRef;
    public Sprite[] playerSprites;
   
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = GameObject.Find("LevelManager");
        playerRef = GameObject.Find("Player").GetComponent<PlayerDye>();

        switch(LevelManager.GetComponent<LevelManager>().levelNumber)
        {
            case 4: diceRolls = spriteList.D20Sprites;
                    BossName.GetComponent<Image>().sprite = diceRolls[21];
                    break;
            case 3: diceRolls = spriteList.D8Sprites;
                    BossName.GetComponent<Image>().sprite = diceRolls[9];
                    break;
            case 2: diceRolls = spriteList.D6Sprites;
                    BossName.GetComponent<Image>().sprite = diceRolls[7];
                    break;
            case 1: diceRolls = spriteList.D2Sprites;
                    BossName.GetComponent<Image>().sprite = diceRolls[3];
                    break;
            default: print("failed");
                    break;
        }

        BossRollSprite.GetComponent<Image>().sprite = diceRolls[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updatePlayerRoll()
    {
        switch(playerRef.attackToUse)
        { 
            case EPlayerAttacks.Attacks.Hit:
                 PlayerRollSprite.GetComponent<Image>().sprite = playerSprites[0];   
                break;
            case EPlayerAttacks.Attacks.DoubleHit:
                 PlayerRollSprite.GetComponent<Image>().sprite = playerSprites[1];   
                break;
            case EPlayerAttacks.Attacks.TripleHit:
                 PlayerRollSprite.GetComponent<Image>().sprite = playerSprites[2];   
                break;
            case EPlayerAttacks.Attacks.Heal:
                 PlayerRollSprite.GetComponent<Image>().sprite = playerSprites[3];   
                break;
            case EPlayerAttacks.Attacks.HealTwice:
                 PlayerRollSprite.GetComponent<Image>().sprite = playerSprites[4];   
                break;
            case EPlayerAttacks.Attacks.HealThrice:
                 PlayerRollSprite.GetComponent<Image>().sprite = playerSprites[5];   
                break;
            case EPlayerAttacks.Attacks.Bomb:
                 PlayerRollSprite.GetComponent<Image>().sprite = playerSprites[6];   
                break;
            case EPlayerAttacks.Attacks.Miss:
                 PlayerRollSprite.GetComponent<Image>().sprite = playerSprites[7];   
                break;
            default: print("failed");
                     break;
        }
    }
}
