using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover : MonoBehaviour
{
    public float speed;
    public AnimationCurve ThrustCurve;

    private float initTime;

    private void Start()
    {
        initTime = Time.timeSinceLevelLoad;
    }

    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * ThrustCurve.Evaluate(Time.timeSinceLevelLoad - initTime));
        this.GetComponent<Rigidbody2D>().AddForce(-transform.right * 1000);
        this.transform.up = this.GetComponent<Rigidbody2D>().velocity.normalized;
    }
}
