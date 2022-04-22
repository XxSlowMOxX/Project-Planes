using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UIHandler : MonoBehaviour
{
    public RectTransform IASNeedle;

    private Quaternion IASRotation;

    private Rigidbody2D _rb2;

    public void Start()
    {
        _rb2 = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        IASRotation.eulerAngles = new Vector3(0, 0,-1.6f *  _rb2.velocity.magnitude);
        IASNeedle.localRotation = IASRotation;
    }
}
