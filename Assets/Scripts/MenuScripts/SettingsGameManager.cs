using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsGameManager : MonoBehaviour
{
   
    Resolution [] res;
    [SerializeField] TMP_Dropdown _dropdownScreenResolutions;
    [SerializeField] TMP_Dropdown _dropdownQaulity;
    [SerializeField] Toggle _FullScreen;
    [SerializeField] Toggle _SoftShadows;
    [SerializeField] Toggle _postprocessing;

    [SerializeField] Slider _sliderMouseSensivity;
    [SerializeField] Slider _sliderSound;
    [SerializeField] Slider _sliderSoundEffects;
    [SerializeField] TMP_Text _textSound;
    [SerializeField] TMP_Text _textSoundEffects;
    [SerializeField] TMP_Text _textMouseSensivity;
    [SerializeField] TMP_Text _apply_text;

    private Color _startColorApplyBtn;


    private void Update() {

        Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

        _textSoundEffects.text =_sliderSoundEffects.value.ToString("F2");
        _textSound.text =_sliderSound.value.ToString("F2");
        _textMouseSensivity.text = _sliderMouseSensivity.value.ToString("F2");
        PlayerPrefs.SetFloat("SoundEffects", _sliderSoundEffects.value);
        PlayerPrefs.SetFloat("Sound", _sliderSound.value);
        PlayerPrefs.SetFloat("MouseSensivity", _sliderMouseSensivity.value);

        PlayerPrefs.SetInt("PP", Convert.ToInt32(_postprocessing.isOn));
        PlayerPrefs.SetInt("FullScreen", Convert.ToInt32(_FullScreen.isOn));
        PlayerPrefs.SetInt("SoftShadows", Convert.ToInt32(_SoftShadows.isOn));

        if(PlayerPrefs.GetFloat("SoftShadows") == 1)
        {
            QualitySettings.shadows = ShadowQuality.All;
        }
        else
        {
            QualitySettings.shadows = ShadowQuality.HardOnly;
        }
        
    }
    private void Start()
    {
        if( PlayerPrefs.GetFloat("SoundEffects") == 0)
        {
             PlayerPrefs.SetFloat("SoundEffects", 0.9f);
             PlayerPrefs.SetFloat("Sound", 0.9f);
        }

        Resolution [] resolution =  Screen.resolutions;
        res = resolution.Distinct().ToArray();
        string[] strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++){
         strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();  
        }
        _dropdownScreenResolutions.AddOptions(strRes.ToList());

        if(PlayerPrefs.GetFloat("SoftShadows") == 1)
        {
            QualitySettings.shadows = ShadowQuality.All;
        }
        else
        {
            QualitySettings.shadows = ShadowQuality.HardOnly;
        }
        

        _dropdownQaulity.AddOptions(QualitySettings.names.ToList());
        _dropdownQaulity.value = QualitySettings.GetQualityLevel(); 
   
        _sliderSoundEffects.value = PlayerPrefs.GetFloat("SoundEffects");
        _sliderSound.value = PlayerPrefs.GetFloat("Sound");
        _sliderMouseSensivity.value = PlayerPrefs.GetFloat("MouseSensivity");
        _postprocessing.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("PP"));
        _FullScreen.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreen"));
        _SoftShadows.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("SoftShadows"));


        
    }

    public void setQuality(){
    QualitySettings.SetQualityLevel(_dropdownQaulity.value);

    }
    public void SetRes(){
        Screen.SetResolution(res[_dropdownScreenResolutions.value].width,res[_dropdownScreenResolutions.value].height,true);
    }
}



