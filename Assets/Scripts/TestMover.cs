using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover : MonoBehaviour
{
    public float speed;

    void Update()
    {
        this.transform.position += this.transform.up * speed * Time.deltaTime;
    }
}
