using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PanelPause;
    

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }

        if(IsPaused)
        {
            PanelPause.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
		    Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
		    Cursor.visible = false;
            PanelPause.SetActive(false);
        }
    }

    public void Menu()
    {   
        IsPaused = false;
        Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
        
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Save()
    {
        
    }
    public void Continue()
    {
        IsPaused = false;
    }
}
