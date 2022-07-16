using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] private int Waittime = 5;
    //private bool waiting = false;
    public Material[] currentAttackTextures;
    public EPlayerAttacks.Attacks[] currentAttacks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown("space") && !waiting) 
       // {
       //     StartCoroutine(CoolDown(Waittime));
      //  }
    }

   // IEnumerator CoolDown(int Waittime)
   // {
       // Attack();

      //  waiting = true;
      //  yield return new WaitForSeconds(Waittime);
      //  waiting = false;
 //   }

   // void Attack()
  //  {
      //  int attack = Random.Range(0, 6);

       // switch (attack)
      //  {
         //   case 6:
        //        print("DoubleHitAll");
         //       break;
         //   case 5:
         //       print("HitAll");
          //      break;
         //   case 4:
         //       print("QuadHit");
        //        break;
          //  case 3:
          //      print("DoubleHit");
        //        break;
         //   case 2:
          //      print("Miss");
           //     break;
         //   default:
         //       print("Hit");
           //     break;
       // }
    //}
}
