using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   [SerializeField] public int levelNumber;
   
   public PlayerData playerDataRef;
   public EPlayerAttacks.Attacks[] startingAttacks;

    // Start is called before the first frame update
    void Start()
    {
        if(levelNumber == 1)
        {
            playerDataRef.attackList = startingAttacks;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossDefeated()
    {
       if(levelNumber == 4)
       {
            SceneManager.LoadScene("EndScreen");
       }
       else
       {
            SceneManager.LoadScene("DiceTrading");
       }
    }
}
