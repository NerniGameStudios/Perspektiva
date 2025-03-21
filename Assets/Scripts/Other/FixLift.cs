using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixLift : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        other.gameObject.GetComponent<Rigidbody>().drag =8.2f;
    }
     private void OnTriggerExit(Collider other) {
        other.gameObject.GetComponent<Rigidbody>().drag =1;
    }
}
