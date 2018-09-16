using System;
using UnityEngine;

public class Check : MonoBehaviour {

    [SerializeField]
    private float FindingRadius;

    [SerializeField]
    private LayerMask findingRayers;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, FindingRadius);
    }

    void Update ()
    {
        Collider[] Colliders = Physics.OverlapSphere(transform.position, FindingRadius, findingRayers);
        Array.Sort(Colliders, new DistanceComparer(transform));

        foreach (Collider item in Colliders)
        {
            Debug.Log(item.name);
        }

    }
}
