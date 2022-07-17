using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestObject
{
    public static int Compare(KeyValuePair<Collider, float> a, KeyValuePair<Collider, float> b)
    {
        return a.Value.CompareTo(b.Value);
    }

    public static GameObject Find(Vector3 origin, float radius, LayerMask layers)
    {
        Collider[] colliders = Physics.OverlapSphere(origin, radius, layers);
        List<KeyValuePair<Collider, float>> objDistances = new List<KeyValuePair<Collider, float>>();
        for (int i = 0; i < colliders.Length; i++)
        {
            objDistances.Add(new KeyValuePair<Collider, float>(colliders[i], (colliders[i].transform.position - origin).magnitude));
        }

        objDistances.Sort(Compare);

        return objDistances[0].Key.gameObject;
    }
}
