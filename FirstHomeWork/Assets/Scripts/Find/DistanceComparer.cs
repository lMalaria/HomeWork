using System.Collections;
using System;
using UnityEngine;

public class DistanceComparer : IComparer {

    private Transform compareTransform;

    public DistanceComparer(Transform compTransform)
    {
        compareTransform = compTransform;
    }

    public int Compare(object a, object b)
    {
        Collider aCollider = a as Collider;
        Collider bCollider = b as Collider;

        Vector3 Offset = aCollider.transform.position - compareTransform.position;
        float aDistance = Offset.sqrMagnitude; 

        Offset = bCollider.transform.position - compareTransform.position;
        float bDistance = Offset.sqrMagnitude;

        return aDistance.CompareTo(bDistance);
    }
}
