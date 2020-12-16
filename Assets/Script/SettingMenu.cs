using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer MasterMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public AudioSource audioSource;
    public AudioClip uiClickSound;

    Resolution[] resolutions;
    Canvas canvas;

    void Start()
    {
        resolutions = Screen.resolutions; 

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
            Pause();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Semua function di sini nantinya akan di call dalam button button dan slider Unity
    ////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume(float sfx)
    {
        MasterMixer.SetFloat("sfxVol",sfx);
    }

    public void SetMusic(float music)
    {
        MasterMixer.SetFloat("musicVol",music);
    }

    public void PlaySoundUI()
    {
        audioSource.clip = uiClickSound;
        audioSource.Play(); 
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }


    public void ExitToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
