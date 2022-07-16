using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    [SerializeField] private GameObject[] diceFaces;
    public Material red;
    // Start is called before the first frame update
    void Start()
    {
       
       foreach (GameObject Face in diceFaces) 
       {
           Face.GetComponent<Renderer>().material = red;
           
       }
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
