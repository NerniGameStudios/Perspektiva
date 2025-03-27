using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoaderVol : MonoBehaviour
{
    public float DefVolume;
    public bool Fon = false;
    public bool NoPause = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(!NoPause)
        {
            if( Pause.IsPaused)
            {
                GetComponent<AudioSource>().Pause();
            }
            else
            {
               GetComponent<AudioSource>().UnPause(); 
            }
        }else
        {
            if( !Pause.IsPaused)
            {
                GetComponent<AudioSource>().Pause();
            }
            else
            {
               GetComponent<AudioSource>().UnPause(); 
            }
        }
            

        if(Fon)
        {
            
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundEffects") * DefVolume;
        }
        else
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound") * DefVolume;
        }
      
    }
}
