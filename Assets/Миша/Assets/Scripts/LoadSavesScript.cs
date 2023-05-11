using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadSavesScript : MonoBehaviour
{
    public GameObject player;
    public AudioMixer audioMixer;
    private void Start()
    {
        LoadGraphicsSettings();
        LoadVolumeSettings();
        LoadControlSettings();
    }

    private void LoadControlSettings()
    {
        LoadMotionControl();
        LoadDashControl();
        LoadShotControl();
        LoadProjectileControl();
    }

    private void LoadGraphicsSettings()
    {
        LoadResolution();
        LoadGraphicsQuality();
        LoadFullScreen();
    }

    private void LoadVolumeSettings()
    {
        LoadMusicVolume();
        LoadEffectsVolume();
        LoadMasterVolume();
    }

    private void LoadMasterVolume()
    {
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0);
        audioMixer.SetFloat("MasterVolume", masterVolume);
    }

    private void LoadEffectsVolume()
    {
        float effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0);
        audioMixer.SetFloat("EffectsVolume", effectsVolume);
    }

    private void LoadMusicVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        audioMixer.SetFloat("MusicVolume", musicVolume);
    }

    private static void LoadFullScreen()
    {
        bool isFullScreen = PlayerPrefs.GetInt("IsFullScreen", 0) == 1 ? true : false;
        Screen.fullScreen = isFullScreen;
    }

    private static void LoadGraphicsQuality()
    {
        int qualityIndex = PlayerPrefs.GetInt("QualityIndex", 0);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    private void LoadResolution()
    {
        Resolution[] resolutions;
        resolutions = Screen.resolutions;
        int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private static void LoadProjectileControl()
    {
        KeyCode[] projectileKeys = { KeyCode.R, KeyCode.E, KeyCode.Tab };
        int projectileValue = PlayerPrefs.GetInt("ActiveProjectile", 0);
        //player.ChangeCurrentProjectile(projectileKeys[projectileValue]);
    }

    private static void LoadShotControl()
    {
        KeyCode[] shotKeys = { KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.F, KeyCode.Space, KeyCode.Return };
        int shotValue = PlayerPrefs.GetInt("ActiveShot", 0);
        //player.ChangeCurrentShot(shotKeys[shotValue]);
    }

    private static void LoadMotionControl()
    {
        string[] motionKeysString = { "WASD", "ARROWS" };
        int motionValue = PlayerPrefs.GetInt("ActiveMotion", 0);
        //player.ChangeCurrentMotion(motionKeysString[motionValue]);
    }

    private static void LoadDashControl()
    {
        KeyCode[] dashKeys = { KeyCode.LeftShift, KeyCode.Space, KeyCode.LeftControl, KeyCode.LeftAlt, KeyCode.RightShift, KeyCode.RightControl, KeyCode.RightAlt };
        int dashValue = PlayerPrefs.GetInt("ActiveDash", 0);
        //player.ChangeCurrentDash(dashKeys[dashValue]);
    }
}
