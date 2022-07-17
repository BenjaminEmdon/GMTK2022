using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDye : Dye
{
    public EnemyData data;

    private EEnemyAttacks.enemyAttacks attacks;

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

        rigidBody.AddRelativeTorque(data.flingTorqueMagnitude * new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)), ForceMode.Impulse);
    }
}