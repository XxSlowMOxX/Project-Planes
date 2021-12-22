using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTest : MonoBehaviour, IEntityInterface
{
    public Type myType { get; set; }
    public Team myTeam { get; set; }

    public float getThermalSignature(Vector3 otherPos)
    {
        float distance = (this.transform.position - otherPos).magnitude;
        return (100.0f / distance) + 25.0f;
    }
}
