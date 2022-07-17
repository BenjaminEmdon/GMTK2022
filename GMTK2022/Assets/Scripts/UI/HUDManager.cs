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
    public EEnemyAttacks.enemyAttacks attackUsed;
    private Image[] healthImages;

    [SerializeField]
    private GameObject healthGrid;
    [SerializeField]
    private GameObject healthPrefab;

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

        InstantiateHealthImages();
        UpdatePlayerHealth(Player.player.health.GetHealth());
    }

    private void OnEnable()
    {
        Player.player.health.onHealthValueChanged.AddListener(UpdatePlayerHealth);
        Player.player.health.onMaxHealthValueChanged.AddListener(UpdatePlayerHealth);
    }

    private void OnDisable()
    {
        Player.player.health.onHealthValueChanged.RemoveListener(UpdatePlayerHealth);
        Player.player.health.onMaxHealthValueChanged.RemoveListener(UpdatePlayerHealth);
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

    void updateBossRoll()
    {
        switch(LevelManager.GetComponent<LevelManager>().levelNumber)
        {
            case 4: updateD20Roll();
                    break;
            case 3: updateD8Roll();
                    break;
            case 2: updateD6Roll();
                    break;
            case 1: updateD2Roll();
                    break;
            default:
                    break;
        }


    }

    void updateD2Roll()
    {
        switch(attackUsed)
        {
            case EEnemyAttacks.enemyAttacks.One:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[1];
                break;
            case EEnemyAttacks.enemyAttacks.Two:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[2];
                break;
            default:
            break;
        }
    }

    void updateD6Roll()
    {
        switch(attackUsed)
        {
            case EEnemyAttacks.enemyAttacks.One:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[1];
                break;
            case EEnemyAttacks.enemyAttacks.Two:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[2];
                break;
            case EEnemyAttacks.enemyAttacks.Three:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[3];
                break;
            case EEnemyAttacks.enemyAttacks.Four:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[4];
                break;
            case EEnemyAttacks.enemyAttacks.Five:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[5];
                break;
            case EEnemyAttacks.enemyAttacks.Six:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[6];
                break;
            default:
            break;
        }
    }
     void updateD8Roll()
    {
        switch(attackUsed)
        {
            case EEnemyAttacks.enemyAttacks.One:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[1];
                break;
            case EEnemyAttacks.enemyAttacks.Two:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[2];
                break;
            case EEnemyAttacks.enemyAttacks.Three:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[3];
                break;
            case EEnemyAttacks.enemyAttacks.Four:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[4];
                break;
            case EEnemyAttacks.enemyAttacks.Five:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[5];
                break;
            case EEnemyAttacks.enemyAttacks.Six:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[6];
                break;
             case EEnemyAttacks.enemyAttacks.Seven:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[7];
                break;
             case EEnemyAttacks.enemyAttacks.Eight:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[8];
                break;
            default:
            break;
        }
    }
     void updateD20Roll()
    {
        switch(attackUsed)
        {
            case EEnemyAttacks.enemyAttacks.One:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[1];
                break;
            case EEnemyAttacks.enemyAttacks.Two:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[2];
                break;
            case EEnemyAttacks.enemyAttacks.Three:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[3];
                break;
            case EEnemyAttacks.enemyAttacks.Four:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[4];
                break;
            case EEnemyAttacks.enemyAttacks.Five:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[5];
                break;
            case EEnemyAttacks.enemyAttacks.Six:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[6];
                break;
             case EEnemyAttacks.enemyAttacks.Seven:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[7];
                break;
             case EEnemyAttacks.enemyAttacks.Eight:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[8];
                break;
            case EEnemyAttacks.enemyAttacks.Nine:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[9];
                break;
            case EEnemyAttacks.enemyAttacks.Ten:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[10];
                break;
            case EEnemyAttacks.enemyAttacks.Eleven:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[11];
                break;
            case EEnemyAttacks.enemyAttacks.Twelve:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[12];
                break;
            case EEnemyAttacks.enemyAttacks.Thirteen:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[13];
                break;
            case EEnemyAttacks.enemyAttacks.Fourteen:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[14];
                break;
             case EEnemyAttacks.enemyAttacks.Fifteen:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[15];
                break;
             case EEnemyAttacks.enemyAttacks.Sixteen:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[16];
                break;
            case EEnemyAttacks.enemyAttacks.Seventeen:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[17];
                break;
            case EEnemyAttacks.enemyAttacks.Eighteen:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[18];
                break;
             case EEnemyAttacks.enemyAttacks.Nineteen:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[19];
                break;
             case EEnemyAttacks.enemyAttacks.Twenty:
                BossRollSprite.GetComponent<Image>().sprite = diceRolls[20];
                break;
            default:
            break;
        }
    }

    private void UpdatePlayerHealth(int value)
    {
        if (healthImages.Length != Player.player.health.GetMaxHealth())
        {
            InstantiateHealthImages();
        }

        for (int i = 0; i < value; i++)
        {
            healthImages[i].enabled = true;
        }
        for (int i = value; i < Player.player.health.GetMaxHealth(); i++)
        {
            healthImages[i].enabled = false;
        }
    }

    private void InstantiateHealthImages()
    {
        foreach (Transform child in healthGrid.transform)
        {
            Destroy(child.gameObject);
        }

        healthImages = new Image[Player.player.health.GetMaxHealth()];
        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i] = Instantiate(healthPrefab, healthGrid.transform).GetComponent<Image>();
            healthImages[i].gameObject.name = $"{healthPrefab.name} [{i + 1}]";
        }
    }
}
