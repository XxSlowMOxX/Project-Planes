using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlightModellTest : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Drag Parameters")]
    public float cdrag = 0.1f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(0, 10);
    }

    void Update()
    {
        Debug.Log(getAerodynamicDrag());
    }

    float getAerodynamicDrag()
    {
        float speedDrag = _rb.velocity.magnitude * cdrag;
        float angleOfAttack = Vector2.Angle(transform.up, _rb.velocity);
        float aoaDragMult = 1.0f + (angleOfAttack / 180) + (Mathf.Sin(Mathf.Deg2Rad * angleOfAttack));
        return angleOfAttack;
    }
}
