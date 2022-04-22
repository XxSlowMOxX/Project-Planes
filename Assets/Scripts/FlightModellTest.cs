using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlightModellTest : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Drag Parameters")]
    public float cdrag = 0.1f;

    [Header("Thrust Parameters")]
    public float maxDryThrust = 1000;
    public float maxWetThrust = 1500;

    private bool Afterburner;
    private float thrustInput = 0.0f;
    [SerializeField]
    private float turnInput = 0.0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(0, 10);
    }

    void Update()
    {
        Afterburner = Input.GetKey(KeyCode.LeftShift);
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        float thrust = Afterburner ? maxWetThrust : maxDryThrust;
        thrust *= thrustInput;
        _rb.AddForce( -1 * _rb.velocity.normalized * getAerodynamicDrag());
        _rb.AddForce(transform.up.normalized * thrust);
        Debug.Log(thrust);
    }

    public void setThrustInput(float tI) { thrustInput = tI; }

    float getAerodynamicDrag()
    {
        float speedDrag = _rb.velocity.sqrMagnitude * cdrag;
        float angleOfAttack = Vector2.Angle(transform.up, _rb.velocity);
        float aoaDragMult = 1.0f + (angleOfAttack / 180) + (Mathf.Sin(Mathf.Deg2Rad * angleOfAttack));
        return speedDrag;
    }
}
