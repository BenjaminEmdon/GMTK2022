using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField]
    private PlayerAttack playerAttack;

    protected override void Awake()
    {
        SetMaxHealth(playerAttack.data.maxHealth);
        base.Awake();
    }
}
