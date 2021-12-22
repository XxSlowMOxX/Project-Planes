using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTest : MonoBehaviour, IEntityInterface
{
    public Type myType { get; set; }
    public Team myTeam { get; set; }

    public GameObject seeker;

    public float maxGimbalAngle = 15;

    public float getThermalSignature(Vector3 otherPos)
    {
        float distance = (this.transform.position - otherPos).magnitude;
        return (20.0f / distance) + 25.0f;
    }

    private bool targetLocked = true;

    void OnDrawGizmos()
    {
        PlaneTest[] Planes = FindObjectsOfType<PlaneTest>();
        MissileTest[] Missiles = FindObjectsOfType<MissileTest>();
        Gizmos.color = Color.red;
        bool locked = false;
        foreach (PlaneTest plane in Planes)
        {
            float angle = Vector3.Angle(transform.up, (plane.transform.position - seeker.transform.position).normalized);
            if (angle < maxGimbalAngle) {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(seeker.transform.position, plane.transform.position);
                Gizmos.color = Color.red;
                locked = true;
            } else
                Gizmos.DrawLine(seeker.transform.position, plane.transform.position);
            if (locked != targetLocked)
            {
                Debug.Log("Target there: " + locked);
                LockSound(locked);
                targetLocked = locked;
            }
        }
    }

    public void LockSound(bool play)
    {
        if (play)
            this.GetComponent<AudioSource>().UnPause();
        else
            this.GetComponent<AudioSource>().Pause();
    }
}
