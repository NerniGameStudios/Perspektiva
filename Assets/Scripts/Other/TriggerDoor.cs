using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    
    

    public Door d;
    public GameObject vis;
    public AudioSource a;

    bool flag;


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            d.Active = false;
            vis.SetActive(false);
            if(!flag)
            {
             a.Play();
             flag = true;
            }
            
        }
    }
}
