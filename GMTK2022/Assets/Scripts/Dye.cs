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

    protected virtual IEnumerator DelayFaceAbility(float delayTime)
    {
        //Debug.Log($"{name}: Waiting to perform Face Ability.", this);
        waitingToPerformAbility = true;
        yield return new WaitForSeconds(delayTime);
        FaceAbility();
        waitingToPerformAbility = false;
    }

    protected virtual void Fire(ProjectileData data, Vector3 dir)
    {
        GameObject proj = ObjectPooler.s_Instance.SpawnObjectFromPool(data.poolTag);
        proj.transform.position = transform.position;

        ProjectileMovement projMvm = proj.GetComponent<ProjectileMovement>();
        if (projMvm != null)
        {
            projMvm.Initialise(data, dir);
        }
    }

    protected virtual void FireRandomDir(ProjectileData data)
    {
        Fire(data, new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)));
    }

    protected virtual void FireConsecutive(ProjectileData data, Vector3 dir, int amount, float interval)
    {
        StartCoroutine(DelayFire(data, dir, amount, interval, false));
    }

    protected virtual void FireConsecutiveRandomDir(ProjectileData data, int amount, float interval)
    {
        StartCoroutine(DelayFire(data, Vector3.zero, amount, interval, true));
    }

    protected virtual IEnumerator DelayFire(ProjectileData data, Vector3 dir, int amount, float interval, bool randomDir = false)
    {
        for (int i = 0; i < amount; i++)
        {
            if (randomDir)
                FireRandomDir(data);
            else
                Fire(data, dir);
            yield return new WaitForSeconds(interval);
        }
    }
}