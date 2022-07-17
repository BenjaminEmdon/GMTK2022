using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField]
    private EnemyDye dye;
    
    protected override void Awake()
    {
        SetMaxHealth(dye.data.maxHealth);
        base.Awake();
    }
}