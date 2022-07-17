using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dye : MonoBehaviour
{
    [Header("Declarations")]
    [SerializeField]
    protected Rigidbody rigidBody;
    [SerializeField]
    protected GameObject[] diceFaces;

    [Header("Ability Settings")]
    [SerializeField]
    protected int delayTime = 1;
    [SerializeField]
    protected LayerMask targetLayerMask;

    protected bool waitingToPerformAbility;
    protected bool hasJustPerformedAbility;
    protected bool isMoving = false;

    protected virtual void Awake()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();
    }
    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        // Update isMoving
        isMoving = rigidBody.velocity.magnitude != 0;

        // Enable face colliders if we're not moving, or disable if we are
        foreach (GameObject face in diceFaces)
        {
            face.GetComponent<BoxCollider>().enabled = !isMoving;
        }

        if (isMoving)
        {
            hasJustPerformedAbility = false;
        }
        else if (!hasJustPerformedAbility && !waitingToPerformAbility)
        {
            StartCoroutine(DelayFaceAbility(delayTime));
        }
    }

    protected virtual void FaceAbility()
    {
        hasJustPerformedAbility = true;
    }

    protected virtual IEnumerator DelayFaceAbility(int delayTime)
    {
        //Debug.Log($"{name}: Waiting to perform Face Ability.", this);
        waitingToPerformAbility = true;
        yield return new WaitForSeconds(delayTime);
        FaceAbility();
        waitingToPerformAbility = false;
    }
}
