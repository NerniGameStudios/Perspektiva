using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    public ElectricalSystem elk;
    
    public GameObject _start;
     public GameObject _plat;
    public GameObject _end;

    public float speed = 1;
    
    void Update()
    {
        if(elk.Active)
        {
            if(_plat.transform.position.y <= _end.transform.position.y)
            {
                _plat.transform.position += Vector3.up * speed * Time.deltaTime;
            }
            
        }
        if(!elk.Active)
        {
            if(_plat.transform.position.y >= _start.transform.position.y)
            {
                _plat.transform.position -= Vector3.up * speed * Time.deltaTime;
            }
            
        }
    }
}
