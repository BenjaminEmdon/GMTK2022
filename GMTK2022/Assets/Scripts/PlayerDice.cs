using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    private int delayTime = 1;
    private bool waitingToAttack;
    private bool hasJustAttacked;
    private bool IsMoving = false;
    [SerializeField] private float speed;
    private Rigidbody rigidBody;
    [SerializeField] private GameObject[] diceFaces;
    public Material[] diceTextures;
    public Material materialToAdd;
    public PlayerAttack playerAttackRef;
    public GameObject playerRef;
    private int i = 0;
    private EPlayerAttacks.Attacks attackToGive;
    
    public EPlayerAttacks.Attacks attackToUse;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
       rigidBody = GetComponent<Rigidbody>();

       //get the players attack arsenal and set the dice sides to reflect which attacks the player has.
       playerRef = GameObject.Find("Player");
       playerAttackRef = playerRef.GetComponent<PlayerAttack>();
       diceTextures = playerAttackRef.currentAttackTextures;

       foreach (GameObject Face in diceFaces) 
       {
           //print(i);
                     
           attackToGive = playerAttackRef.currentAttacks[i];
           Face.GetComponent<InitiateSide>().attack = attackToGive; 
           i++;

           switch(attackToGive)
           {
           
                case EPlayerAttacks.Attacks.Hit:
                         materialToAdd = diceTextures[0];
                         break;
                case EPlayerAttacks.Attacks.DoubleHit:
                         materialToAdd = diceTextures[1];
                         break;         
                case EPlayerAttacks.Attacks.TripleHit:
                         materialToAdd = diceTextures[2];
                         break;
                case EPlayerAttacks.Attacks.Heal:
                         materialToAdd = diceTextures[3];
                         break;
                case EPlayerAttacks.Attacks.HealTwice:
                         materialToAdd = diceTextures[4];
                         break;
                case EPlayerAttacks.Attacks.HealThrice:
                         materialToAdd = diceTextures[5];
                         break;
                case EPlayerAttacks.Attacks.Bomb:
                         materialToAdd = diceTextures[6];
                         break;
                case EPlayerAttacks.Attacks.Miss:
                         materialToAdd = diceTextures[7];
                         break;
                default: print("failed");
                         break;
           }
           
           Face.GetComponent<Renderer>().material = materialToAdd;
           
       }
    
    }

    // Update is called once per frame
    void Update()
    {
        speed = rigidBody.velocity.magnitude;
        if(speed == 0)
        {
            IsMoving = false;
            foreach (GameObject Face in diceFaces) 
            {
                Face.GetComponent<BoxCollider>().enabled = true;
            }
        }
        else
        {
            IsMoving = true;
            foreach (GameObject Face in diceFaces) 
            {
                Face.GetComponent<BoxCollider>().enabled = false;
            }
            hasJustAttacked = false;
        }
        
        if(IsMoving == false)
        {
           if(hasJustAttacked == false)
           {
              
              if(waitingToAttack == false)
              {
                
                Debug.Log("Waiting");
                StartCoroutine(DelayAction(delayTime));
              }
              
              
           }

        }
    }

    IEnumerator DelayAction(int delayTime)
    {
        waitingToAttack = true;
        yield return new WaitForSeconds(delayTime);
        PerformAttack();
        waitingToAttack = false;
        hasJustAttacked = true;
    }

    void PerformAttack()
    {
        //check which direction is facing up and change enum to that
        Debug.Log("hi");
        
        switch (attackToUse)
        {
            
            case EPlayerAttacks.Attacks.Hit: print("Hit");
                    break;
            case EPlayerAttacks.Attacks.DoubleHit: print("DoubleHit");
                    break;
            case EPlayerAttacks.Attacks.TripleHit: print("TripleHit");
                    break;
            case EPlayerAttacks.Attacks.Heal: print("Heal");
                    break;
            case EPlayerAttacks.Attacks.HealTwice: print("HealTwice");
                    break;
            case EPlayerAttacks.Attacks.HealThrice: print("HealThrice");
                    break;
            case EPlayerAttacks.Attacks.Bomb: print("Bomb");
                    break;
            case EPlayerAttacks.Attacks.Miss: print("Miss");
                    break;
            default: print("Failed");
                     break;   
        }
    }


}

 