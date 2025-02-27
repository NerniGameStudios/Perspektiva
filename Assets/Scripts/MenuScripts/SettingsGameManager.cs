using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsGameManager : MonoBehaviour
{
    List<string> _listScreenResolutions = new List<string>();
    Resolution[] _ScreenRes;

    [SerializeField] TMP_Dropdown _dropdownScreenResolutions;
    [SerializeField] TMP_Dropdown _dropdownTextureResolutions;
    [SerializeField] TMP_Dropdown _dropdownSmoothing;

    [SerializeField] bool _isFullScreen = true;


    private void Awake()
    {
        _ScreenRes = Screen.resolutions;
        foreach (Resolution screen in _ScreenRes)
        {
            _listScreenResolutions.Add(screen.width + "x" + screen.height);
            Debug.Log(screen.width + "x" + screen.height);
        }
        _dropdownScreenResolutions.ClearOptions();
        _dropdownScreenResolutions.AddOptions(_listScreenResolutions);
    }

    public void SetFullScreen()
    {
        _isFullScreen = !_isFullScreen;
        Screen.fullScreen = _isFullScreen;
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(_ScreenRes[r].width, _ScreenRes[r].height, _isFullScreen);
    }
}
