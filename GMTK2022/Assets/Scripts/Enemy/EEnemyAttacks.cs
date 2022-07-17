using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EEnemyAttacks : MonoBehaviour
{
    public enum enemyAttacks
    {
        Null,
        GroundPound,
        Ring,
        Spiral,
        Star,
        Cross,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven,
        Twelve,
        Thirteen,
        Fourteen,
        Fifteen,
        Sixteen,
        Seventeen,
        Eighteen,
        Nineteen,
        Twenty,
        selfDamage,
        selfDestruct
    }

    
    // double/triple hit/heal is probably not a good idea, would be better to use singular Hit/Heal and use an int to determine how many hits/heals
    // but idk cos we're using an enum
    // -jamie

    //using an enum so it's easier to create specific attacks for enemies and special abilities, I would assume there is a much better way 
    //than doing this with ints or dictionaries or something
    // the only one which will be awkward is D20 tho, the others have barely any attacks anyway

    // "wow you guys should add a 100 sided dice!!" -some guy in the future, probably
}
