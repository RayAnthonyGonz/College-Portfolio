using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{   
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    public Toggle fullScreenToggle;
    public SaveandLoad SnL;
    public static int DropdownValue = 0;
    public static bool isFullscreen;
    public static float volume = 0; 
    [SerializeField] private Slider volumeSlider = null;
    public static float volumeValue;
    Resolution[] resolutions;
    Resolution resolution;
    public int resolutionIndex;

    void Start()
    {   
        
        if(ES2.Exists(SnL.filename5))
        {
            LoadSavedSettings();
        }
        SnL = GameObject.Find("Save and Load").GetComponent<SaveandLoad>();
        resolutions = Screen.resolutions;
        CreateResolution();
        resolutionDropdown.value = SaveandLoad.savedResolutionValue;//displays the saved resolution on start
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        
        
        
        

    }
    
    public void CreateResolution()
    {   //Creates max resolution of the user

        resolutionDropdown.ClearOptions();
        
        
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + "@" + resolutions[i].refreshRate;
            
            options.Add(option);
            if (Mathf.Approximately(resolutions[i].width, Screen.currentResolution.width) &&
                Mathf.Approximately(resolutions[i].height, Screen.currentResolution.height) && 
                Mathf.Approximately(resolutions[i].refreshRate, Screen.currentResolution.refreshRate))
            {
                currentResolutionIndex = i;
            }
                
            
            
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        
        resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }

    public void SetVolume(float volume)
    {   
        audioMixer.SetFloat("volume", volume);
        volumeValue = volumeSlider.value;
        
    }

    public void SetFullscreen (bool isFullscreen)
    {   
        Debug.Log(isFullscreen);
        
        Screen.fullScreen = isFullscreen;
        
    }

    public void LoadSavedSettings()
    {
        SnL.LoadSettings();
        volumeSlider.value = SaveandLoad.savedVolume;
        resolutionDropdown.value = SaveandLoad.savedResolutionValue;
        
    }

    // public void changeBool(bool isFullscreen)
    // {
    //     if(isFullscreen == false)
    //     {
    //         isFullscreen == true;
    //     }
    //     else
    //     {
    //         isFullscreen == false;
    //     }
    // }
    
}
