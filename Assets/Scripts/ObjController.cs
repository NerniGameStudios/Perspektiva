using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public GameObject Obj;
    public GameObject Pointer;
    public GameObject UIobj;
Vector3 scll;
  
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
   
        Ray ray = new Ray(transform.position,transform.forward);
        


        RaycastHit hit;
        Physics.Raycast(ray,out hit);

        if(hit.collider.gameObject.tag == "Obj"){Obj = hit.collider.gameObject; UIobj.SetActive(true);}
        else{UIobj.SetActive(false); }

            
        if(Input.GetMouseButtonDown(0)){
           scll = Obj.transform.localScale;
        }
        
        if(Input.GetMouseButton(0))
        {
           // Vector3 scl = Obj.transform.localScale;
            float scale = Vector3.Distance(Obj.transform.position,transform.position);
            Obj.transform.localScale =  Vector3.one * 0.08F * scale;
            
            Obj.GetComponent<BoxCollider>().enabled = false;
            Obj.GetComponent<Rigidbody>().isKinematic = true;

            Obj.transform.position = hit.point + hit.normal;
            Obj.transform.rotation = Pointer.transform.rotation;

            Obj.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {

            Obj.GetComponent<BoxCollider>().enabled = true;
            Obj = null;
        }
        

        
    }
}
