using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject _start;
    public LineRenderer lr;
    public GameObject _end;
    GameObject Buff;

   private void Start() {
    lr.positionCount = 2;
   }
    void Update()
    {
        Ray ray = new Ray(_start.transform.position,-transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray,out hit);

        lr.SetPosition(0, _start.transform.position);
        lr.SetPosition(1, hit.point);

       Buff = hit.collider.gameObject;
        if(hit.collider.gameObject.tag == "Finish")_end.GetComponent<ElectricalSystem>().Active =true;
        else
        {
            _end.gameObject.GetComponent<ElectricalSystem>().Active =false;
        }    


    }
}
