using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool Active;
    public GameObject _start;
     public GameObject _plat;
    public GameObject _end;
    public float speed = 3;
    bool flag =false;
    
    void FixedUpdate()
    {
        if(Active)
        {
            if(_plat.transform.position.y <= _end.transform.position.y)
            {
                _plat.transform.position += Vector3.up * speed * Time.fixedDeltaTime;
                
                
            }
            
        }
        if(!Active)
        {
            if(_plat.transform.position.y >= _start.transform.position.y)
            {
                _plat.transform.position -= Vector3.up * speed * Time.fixedDeltaTime;
            }
            
        }
        
    }
}
