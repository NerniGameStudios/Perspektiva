using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System;

public class PPSettings : MonoBehaviour
{
 
    
  void Update() {
         GetComponent<PostProcessVolume>().isGlobal = Convert.ToBoolean(PlayerPrefs.GetInt("PP"));
    }
    

   
}
