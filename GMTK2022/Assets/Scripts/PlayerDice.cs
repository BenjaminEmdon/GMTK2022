using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    [SerializeField] private GameObject[] diceFaces;
    public Material[] diceTextures;
    public Material materialToAdd;
    public PlayerAttack playerAttackRef;
    public GameObject playerRef;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
       playerRef = GameObject.Find("Player");
       playerAttackRef = playerRef.GetComponent<PlayerAttack>();
       diceTextures = playerAttackRef.currentAttackList;

       foreach (GameObject Face in diceFaces) 
       {
           print(i);
           materialToAdd = diceTextures[i]; 
           Face.GetComponent<Renderer>().material = materialToAdd;
           i++;
           
       }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
