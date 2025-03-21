using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisxWakeUP : MonoBehaviour
{
    Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.WakeUp();
    }
}
