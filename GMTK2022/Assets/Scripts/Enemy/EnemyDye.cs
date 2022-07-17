using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDye : Dye
{
    public EnemyData data;
    public ProjectileData projData;

    [HideInInspector]
    public EEnemyAttacks.enemyAttacks attack;

    [SerializeField]
    [Tooltip("The delay in seconds after performing a Face Ability before it attempts to move again.")]
    private float moveDelay = 3.0f;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FaceAbility()
    {
        base.FaceAbility();

        switch (attack)
        {
            case EEnemyAttacks.enemyAttacks.Null:
                break;
            case EEnemyAttacks.enemyAttacks.GroundPound:
                break;
            case EEnemyAttacks.enemyAttacks.Ring:
                break;
            case EEnemyAttacks.enemyAttacks.Spiral:
                break;
            case EEnemyAttacks.enemyAttacks.Star:
                break;
            case EEnemyAttacks.enemyAttacks.Cross:
                break;
            case EEnemyAttacks.enemyAttacks.One:
                FireRandomDir(projData);
                break;
            case EEnemyAttacks.enemyAttacks.Two:
                FireConsecutiveRandomDir(projData, 2, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Three:
                FireConsecutiveRandomDir(projData, 3, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Four:
                FireConsecutiveRandomDir(projData, 4, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Five:
                FireConsecutiveRandomDir(projData, 5, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Six:
                FireConsecutiveRandomDir(projData, 6, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Seven:
                FireConsecutiveRandomDir(projData, 7, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Eight:
                FireConsecutiveRandomDir(projData, 8, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Nine:
                FireConsecutiveRandomDir(projData, 9, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Ten:
                FireConsecutiveRandomDir(projData, 10, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Eleven:
                FireConsecutiveRandomDir(projData, 11, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Twelve:
                FireConsecutiveRandomDir(projData, 12, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Thirteen:
                FireConsecutiveRandomDir(projData, 13, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Fourteen:
                FireConsecutiveRandomDir(projData, 14, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Fifteen:
                FireConsecutiveRandomDir(projData, 15, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Sixteen:
                FireConsecutiveRandomDir(projData, 16, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Seventeen:
                FireConsecutiveRandomDir(projData, 17, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Eighteen:
                FireConsecutiveRandomDir(projData, 18, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Nineteen:
                FireConsecutiveRandomDir(projData, 19, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.Twenty:
                FireConsecutiveRandomDir(projData, 20, data.fireInterval);
                break;
            case EEnemyAttacks.enemyAttacks.selfDamage:
                break;
            case EEnemyAttacks.enemyAttacks.selfDestruct:
                break;
            default:
                break;
        }

        StartCoroutine(DelayMove(moveDelay));
    }

    protected override IEnumerator DelayFaceAbility(float delayTime)
    {
        return base.DelayFaceAbility(delayTime);
    }

    protected virtual IEnumerator DelayMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Move();
    }

    // Flings itself in the direction of the player
    protected virtual void Move()
    {
        Vector3 dir = (Player.player.transform.position - transform.position).normalized + data.flingDirOffset;
        rigidBody.AddForce(dir * data.flingMagnitude * 5.0f, ForceMode.Impulse);

        rigidBody.AddRelativeTorque(data.flingTorqueMagnitude * new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)), ForceMode.Impulse);
    }
}