using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateSide : MonoBehaviour
{
    private GameObject FaceBox;

    [SerializeField]
    private Dye dye;

    public EPlayerAttacks.Attacks playerAttack;
    public EEnemyAttacks.enemyAttacks enemyAttack;

    // Start is called before the first frame update
    void Start()
    {
        FaceBox = GameObject.Find("PlayerFaceDetector");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == FaceBox)
        {
            PlayerDye playerDye = dye as PlayerDye;
            if (playerDye != null)
            {
                playerDye.attackToUse = playerAttack;
            }
            else
            {
                EnemyDye enemyDye = dye as EnemyDye;
                if (enemyDye != null)
                {
                    enemyDye.attack = enemyAttack;
                }
            }
        }
    }
}