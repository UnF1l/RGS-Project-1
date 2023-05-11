using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettingsScript : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;
    public Toggle toggleFullscreen;
    private Resolution[] resolutions;
    private const int DEFAULT_QUALITY_LEVEL = 2;
    public bool isAnySettings = false;

    private void Start()
    {
        resolutions = Screen.resolutions;
        isAnySettings = PlayerPrefs.GetInt("IsAnySettings", 0) == 1 ? true : false;
        PopulateResolutionDropdown();
        if (!isAnySettings)
        {
            SetDefaultScreenSettings();
        }
        SetupSettings();
    }

    private void SetupSettings()
    {
        SetResolution(PlayerPrefs.GetInt("ResolutionIndex", 0));
        SetQuality(PlayerPrefs.GetInt("QualityIndex", 0));
        SetFullscreen(PlayerPrefs.GetInt("IsFullScreen", 0) == 1 ? true : false);
    }    

    private void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if ((resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) && (!isAnySettings))
            {
                currentResolutionIndex = i;
            }
        }
        if (isAnySettings)
        {
            currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void SetDefaultScreenSettings()
    {
        Screen.fullScreen = true;
        QualitySettings.SetQualityLevel(DEFAULT_QUALITY_LEVEL);
        isAnySettings = true;
        PlayerPrefs.SetInt("IsAnySettings", isAnySettings ? 1 : 0);
    }

    public void SetResolution(int resolutionIndex)
    {
        resolutionDropdown.value = resolutionIndex;
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
    }


    public void SetQuality(int qualityIndex)
    {
        qualityDropdown.value = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        toggleFullscreen.isOn = isFullScreen;
        PlayerPrefs.SetInt("IsFullScreen", isFullScreen ? 1 : 0);
    }
}
