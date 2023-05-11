using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider effectsSlider;
    public Slider generalSlider;

    private const float MIN_VOLUME_LEVEL = -80f;
    private const float MIN_AUDIOMIXER_LEVEL = -19.9f;

    private void Start()
    {
        SetupSettings();
    }

    private void SetupSettings()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0);
        generalSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0);
    }

    public void SetVolumeMusic(float volume)
    {
        volume = volume < MIN_AUDIOMIXER_LEVEL ? MIN_VOLUME_LEVEL : volume;
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetVolumeSoundEffects(float volume)
    {
        volume = volume < MIN_AUDIOMIXER_LEVEL ? MIN_VOLUME_LEVEL : volume;
        audioMixer.SetFloat("EffectsVolume", volume);
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }
    public void SetVolumeGeneral(float volume)
    {
        volume = volume < MIN_AUDIOMIXER_LEVEL ? MIN_VOLUME_LEVEL : volume;
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
