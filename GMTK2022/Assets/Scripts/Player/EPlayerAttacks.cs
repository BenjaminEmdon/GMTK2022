using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPlayerAttacks : MonoBehaviour
{
    public enum Attacks
    {
        Null,
        Hit,
        Miss,
        DoubleHit,
        TripleHit,
        Bomb,
        Heal,
        HealTwice,
        HealThrice,
    }

    // double/triple hit/heal is probably not a good idea, would be better to use singular Hit/Heal and use an int to determine how many hits/heals
    // but idk cos we're using an enum
    // -jamie
}
