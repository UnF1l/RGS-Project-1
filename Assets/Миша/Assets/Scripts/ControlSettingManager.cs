using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlSettingManager : MonoBehaviour
{
    public string activeMotion = "WASD";
    public KeyCode activeDash = KeyCode.LeftShift;
    public KeyCode activeShot = KeyCode.Mouse0;
    public KeyCode activeProjectile = KeyCode.R;

    public TMPro.TMP_Dropdown motionDropdown;
    public TMPro.TMP_Dropdown dashDropdown;
    public TMPro.TMP_Dropdown shotDropdown;
    public TMPro.TMP_Dropdown projectileDropdown;

    KeyCode[] dashKeys = { KeyCode.LeftShift, KeyCode.Space, KeyCode.LeftControl, KeyCode.LeftAlt, KeyCode.RightShift, KeyCode.RightControl, KeyCode.RightAlt };
    KeyCode[] shotKeys = { KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.F, KeyCode.Space, KeyCode.Return };
    KeyCode[] projectileKeys = { KeyCode.R, KeyCode.E, KeyCode.Tab };
    string[] motionKeysString = { "WASD", "ARROWS" };

    public GameObject player;

    private void Start()
    {
        SetupSettings();
    }

    private void SetupSettings()
    {
        MotionSettings();
        DashSettings();
        ShotSettings();
        ProjectileSettings();
    }

    private void ProjectileSettings()
    {
        int projectileValue = PlayerPrefs.GetInt("ActiveProjectile");
        SetActiveProjectile(projectileValue);
        projectileDropdown.value = projectileValue;
    }

    private void ShotSettings()
    {
        int shotValue = PlayerPrefs.GetInt("ActiveShot");
        SetActiveShot(shotValue);
        shotDropdown.value = shotValue;
    }

    private void DashSettings()
    {
        int dashValue = PlayerPrefs.GetInt("ActiveDash");
        SetActiveDash(dashValue);
        dashDropdown.value = dashValue;
    }

    private void MotionSettings()
    {
        int motionValue = PlayerPrefs.GetInt("ActiveMotion");
        SetActiveMotion(motionValue);
        motionDropdown.value = motionValue;
    }

    public void SetActiveMotion(int _activeMotion)
    {
        activeMotion = motionKeysString[_activeMotion];
        PlayerPrefs.SetInt("ActiveMotion", _activeMotion);
        //player.ChangeCurrentMotion(activeMotion);
    }    
    public void SetActiveDash(int _activeDash)
    {
        activeDash = dashKeys[_activeDash];
        if ((activeDash == activeShot) || (activeDash == activeProjectile))
        {
            activeDash = dashKeys[0];
            dashDropdown.GetComponent<TMP_Dropdown>().value = 0;
        }
        PlayerPrefs.SetInt("ActiveDash", dashDropdown.GetComponent<TMP_Dropdown>().value);
        //player.ChangeCurrentDash(activeDash);
    }

    public void SetActiveShot(int _activeShot)
    {
        activeShot = shotKeys[_activeShot];
        if ((activeShot == activeDash) || (activeShot == activeProjectile))
        {
            activeShot = KeyCode.Mouse0;
            shotDropdown.GetComponent<TMP_Dropdown>().value = 0;
        }
        PlayerPrefs.SetInt("ActiveShot", shotDropdown.GetComponent<TMP_Dropdown>().value);
        //player.ChangeCurrentShot(activeShot);
    }

    public void SetActiveProjectile(int _activeProjectile)
    {
        activeProjectile = projectileKeys[_activeProjectile];
        if ((activeProjectile == activeDash) || (activeProjectile == activeShot))
        {
            activeProjectile = KeyCode.R;
            projectileDropdown.GetComponent<TMP_Dropdown>().value = 0;
        }
        PlayerPrefs.SetInt("ActiveProjectile", projectileDropdown.GetComponent<TMP_Dropdown>().value);
        //player.ChangeCurrentProjectile(activeProjectile);
    }
}
