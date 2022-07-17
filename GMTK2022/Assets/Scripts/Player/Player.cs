using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;

    public PlayerHealth health;

    private void Awake()
    {
        player = this;
    }
}
