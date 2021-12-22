using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTest : MonoBehaviour, IEntityInterface
{
    public Type myType { get; set; }
    public Team myTeam { get; set; }

    public GameObject seeker;
    public float maxGimbalAngle = 15;
    public AnimationCurve thrustCurve;

    private bool launched;
    private PlaneTest target;
    private float launchTime;

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
                target = plane;
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !launched)
        {
            launched = true;
            launchTime = Time.timeSinceLevelLoad;
        }
    }

    public void FixedUpdate()
    {
        if (launched)
        {
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * thrustCurve.Evaluate(Time.timeSinceLevelLoad - launchTime));
            if(target != null)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector3.RotateTowards(this.GetComponent<Rigidbody2D>().velocity, target.gameObject.transform.position - transform.position, 0.05f, 0);
            }
            transform.up = GetComponent<Rigidbody2D>().velocity.normalized;
        }
    }

    public void LockSound(bool play)
    {
        if (play)
            this.GetComponent<AudioSource>().UnPause();
        else
        {
            this.GetComponent<AudioSource>().Pause();
            target = null;
        }
    }
}
