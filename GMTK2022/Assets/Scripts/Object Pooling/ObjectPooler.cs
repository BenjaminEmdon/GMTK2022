using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler s_Instance;

    [Header("Pooled Obj Information")]
    private List<GameObject> pooledObjs = new List<GameObject>();
    [SerializeField]
    private GameObject objToPool;
    [SerializeField]
    private int poolSize;

    private void Awake()
    {
        // singleton moment
        if (s_Instance == null)
        {
            s_Instance = FindObjectOfType(typeof(ObjectPooler)) as ObjectPooler;
        }
        if (s_Instance == null)
        {
            s_Instance = this;
        }

        if (objToPool == null || poolSize <= 0)
            return;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objToPool, transform);
            obj.name = $"{objToPool.name} [{i + 1}]";
            obj.SetActive(false);
            pooledObjs.Add(obj);
        }
    }

    public GameObject SpawnObjectFromPool()
    {
        GameObject objToSpawn = GetPooledObject();
        objToSpawn.SetActive(true);

        IPooledObject pooledObj = objToSpawn.GetComponent<IPooledObject>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        return objToSpawn;
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!pooledObjs[i].activeInHierarchy)
            {
                return pooledObjs[i];
            }
        }
        return null;
    }
}