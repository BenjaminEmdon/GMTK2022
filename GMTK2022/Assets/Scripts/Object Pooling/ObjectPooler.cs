using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler s_Instance;

    [System.Serializable]
    public struct Pool
    {
        public string tag;
        public GameObject obj;
        public int size;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();      // Dictionary of pools associating GameObjects with tags


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

        // Instantiate object pools
        for (int i = 0; i < pools.Count; i++)
        {
            Queue<GameObject> pool = new Queue<GameObject>();
            for (int j = 0; j < pools[i].size; j++)
            {
                GameObject obj = Instantiate(pools[i].obj, transform);
                obj.name = $"{pools[i].obj.name} [{j + 1}]";
                obj.SetActive(false);
                pool.Enqueue(obj);
            }

            poolDictionary.Add(pools[i].tag, pool);
        }
    }

    public GameObject SpawnObjectFromPool(string tag)
    {
        GameObject objToSpawn = GetPooledObject(tag);

        if (objToSpawn == null)
            return null;

        objToSpawn.SetActive(true);

        IPooledObject pooledObj = objToSpawn.GetComponent<IPooledObject>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objToSpawn);

        return objToSpawn;
    }

    public GameObject GetPooledObject(string tag)
    {
        // Check if tag exists within our dictionary of pools
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Object Pool with tag {tag} could not be found!", this);
            return null;
        }
        else
        {
            return poolDictionary[tag].Dequeue();
        }
    }
}