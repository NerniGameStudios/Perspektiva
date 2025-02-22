using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeCamera : MonoBehaviour
{
  public float amount = 1;
  public float speed = 1;
public int axis;
  private Vector3 startPos;
  private float distaton;
  private Vector3 rotation;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        
        distaton += (transform.position - startPos).magnitude;
        startPos = transform.position;
        switch(axis){
        case 1:
        rotation.x = Mathf.Sin(distaton * speed) * amount;
        break;
        case 2:
        rotation.y = Mathf.Sin(distaton * speed) * amount;
        break;
        case 3:
        rotation.z = Mathf.Sin(distaton * speed) * amount;
        break;
        }
        rotation.z = Mathf.Sin(distaton * speed) * amount;
        transform.localEulerAngles = rotation;
    }
}
