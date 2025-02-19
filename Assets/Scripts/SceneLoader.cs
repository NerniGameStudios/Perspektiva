using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
 
    public void Load(int IDscene)
    {
        SceneManager.LoadScene(IDscene);
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}
