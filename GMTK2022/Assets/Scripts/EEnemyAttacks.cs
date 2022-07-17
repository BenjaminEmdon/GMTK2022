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
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20
    }

    
    // double/triple hit/heal is probably not a good idea, would be better to use singular Hit/Heal and use an int to determine how many hits/heals
    // but idk cos we're using an enum
    // -jamie

    //using an enum so it's easier to create specific attacks for enemies and special abilities, I would assume there is a much better way 
    //than doing this with ints or dictionaries or something
    // the only one which will be awkward is D20 tho, the others have barely any attacks anyway
}
