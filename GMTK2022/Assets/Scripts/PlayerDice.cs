using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDice : Dye
{
    public Material[] diceTextures;

    [HideInInspector]
    public PlayerAttack playerAttack;
    [HideInInspector]
    public EPlayerAttacks.Attacks attackToUse;

    [Header("Projectile Data")]
    [SerializeField]
    private ProjectileData hitProjectileData;

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();


        //get the players attack arsenal and set the dice sides to reflect which attacks the player has.
        playerAttack = Player.player.GetComponent<PlayerAttack>();
        diceTextures = playerAttack.currentAttackTextures;

        Material materialToAdd = null;

        for (int i = 0; i < diceFaces.Length; i++)
        {
            EPlayerAttacks.Attacks attackToGive = playerAttack.currentAttacks[i];
            diceFaces[i].GetComponent<InitiateSide>().attack = attackToGive;

            switch (attackToGive)
            {

                case EPlayerAttacks.Attacks.Hit:
                    materialToAdd = diceTextures[0];
                    break;
                case EPlayerAttacks.Attacks.DoubleHit:
                    materialToAdd = diceTextures[1];
                    break;
                case EPlayerAttacks.Attacks.TripleHit:
                    materialToAdd = diceTextures[2];
                    break;
                case EPlayerAttacks.Attacks.Heal:
                    materialToAdd = diceTextures[3];
                    break;
                case EPlayerAttacks.Attacks.HealTwice:
                    materialToAdd = diceTextures[4];
                    break;
                case EPlayerAttacks.Attacks.HealThrice:
                    materialToAdd = diceTextures[5];
                    break;
                case EPlayerAttacks.Attacks.Bomb:
                    materialToAdd = diceTextures[6];
                    break;
                case EPlayerAttacks.Attacks.Miss:
                    materialToAdd = diceTextures[7];
                    break;
                default:
                    print("failed");
                    break;
            }

            diceFaces[i].GetComponent<Renderer>().material = materialToAdd;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        /*
        if (Input.GetKeyDown(KeyCode.H))
        {
            ATKHit();
        }
        */
    }

    protected override void FaceAbility()
    {
        base.FaceAbility();

        //Debug.Log($"We're now performing FaceAbility: {attackToUse}", this);

        // Perform the face ability that is currently facing up
        switch (attackToUse)
        {
            case EPlayerAttacks.Attacks.Hit:
                ATKHit();
                break;
            case EPlayerAttacks.Attacks.DoubleHit:
                ATKDoubleHit();
                break;
            case EPlayerAttacks.Attacks.TripleHit:
                ATKTripleHit();
                break;
            case EPlayerAttacks.Attacks.Heal:
                ATKHeal();
                break;
            case EPlayerAttacks.Attacks.HealTwice:
                ATKDoubleHeal();
                break;
            case EPlayerAttacks.Attacks.HealThrice:
                ATKTripleHeal();
                break;
            case EPlayerAttacks.Attacks.Bomb:
                ATKBomb();
                break;
            case EPlayerAttacks.Attacks.Miss:
                ATKMiss();
                break;
            default:
                Debug.LogError("PerformAttack failed - no attack to use.");
                break;
        }
    }

    void ATKHit()
    {
        GameObject proj = ObjectPooler.s_Instance.SpawnObjectFromPool(hitProjectileData.poolTag);
        proj.transform.position = transform.position;

        ProjectileMovement projMvm = proj.GetComponent<ProjectileMovement>();
        if (projMvm != null)
        {
            // calculate direction to nearest enemy
            Vector3 dir = (FindClosestObject.Find(proj.transform.position, 50.0f, targetLayerMask).transform.position - proj.transform.position).normalized;

            // set variables from ProjectileData scriptable object
            projMvm.Initialise(hitProjectileData, dir);
        }
    }

    void ATKDoubleHit()
    {

    }

    void ATKTripleHit()
    {

    }

    void ATKHeal()
    {

    }

    void ATKDoubleHeal()
    {

    }

    void ATKTripleHeal()
    {

    }

    void ATKBomb()
    {

    }

    void ATKMiss()
    {
        SceneManager.LoadScene("DiceTrading");
    }
}

 