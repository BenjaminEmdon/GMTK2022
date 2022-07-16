using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateSide : MonoBehaviour
{
  public Material materialApplied;
  private GameObject FaceDetectorRef;
  private BoxCollider FaceBox;
  private BoxCollider SelfCollider;
  private GameObject PlayerD6Ref;
  private PlayerDice PlayerDiceRef;
  [SerializeField] public EPlayerAttacks.Attacks attack;
    // Start is called before the first frame update
    void Start()
    {
        PlayerD6Ref = GameObject.Find("Player D6");
        PlayerDiceRef = PlayerD6Ref.GetComponent<PlayerDice>();

        FaceDetectorRef = GameObject.Find("PlayerFaceDetector");
        FaceBox = FaceDetectorRef.GetComponent<BoxCollider>();
        
        SelfCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
      
    
    }

    private void OnTriggerEntered(Collider SelfCollider, Collider Facebox)
    {
        PlayerDiceRef.attackToUse = attack;
    }
}
