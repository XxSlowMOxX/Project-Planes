using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Plane,
    Missile,
    Countermeasure
}

public enum Team
{
    Red,
    Blue
}

interface IEntityInterface
{
    Type myType { get; set; }
    Team myTeam { get; set; }
    public float getThermalSignature(Vector3 otherPos);
}
