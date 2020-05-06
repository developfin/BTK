using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuUI : MonoBehaviour
{
    public int NewGameScene; // Переменная для перехода при нажатии "Новая Игра"

    // ============= Переменные настроек =============
    public Dropdown ResolutionDropdown; // Выпадающий список с разрешениями
    Resolution[] res; // Массив разрешений

    public Toggle Fullscreen; // Переключатель полноэкранного режима

    public Dropdown QualitySettinsDropdown; // Выпадающий список с качеством графики

    public AudioMixer am; // Аудио Миксер для настроек звука в игре
    /*private bool muted = false;
    public Toggle MuteToggle;*/
    public Slider VolumeSlider;
    // ============= Переменные настроек =============

    void Start()
    {
        //================================= Resolution =================================

        if (PlayerPrefs.HasKey("FullScreen"))
        {
            if (PlayerPrefs.GetInt("FullScreen") == 0)
            {
                Screen.fullScreen = false;
                Fullscreen.isOn = Screen.fullScreen;
            }
            else
            {
                Screen.fullScreen = true;
                Fullscreen.isOn = Screen.fullScreen;
            }
        }
        else
        {
            Screen.fullScreen = true;
            Fullscreen.isOn = Screen.fullScreen;
        }

        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();
        string[] strRes = new string[resolution.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
        }
        ResolutionDropdown.ClearOptions();
        ResolutionDropdown.AddOptions(strRes.ToList());
        if (PlayerPrefs.HasKey("Resolution"))
        {
            ResolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
            Screen.SetResolution(res[PlayerPrefs.GetInt("Resolution")].width, res[PlayerPrefs.GetInt("Resolution")].height, Screen.fullScreen);
        }
        else
        {
            Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
            ResolutionDropdown.value = res.Length - 1;
        }


        //==============================================================================



        //================================== Quality ===================================

        QualitySettinsDropdown.ClearOptions();
        QualitySettinsDropdown.AddOptions(QualitySettings.names.ToList());
        if (PlayerPrefs.HasKey("Quality"))
        {
            QualitySettinsDropdown.value = PlayerPrefs.GetInt("Quality");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        }
        else
        {
            QualitySettinsDropdown.value = QualitySettings.GetQualityLevel();
        }

        //==============================================================================

        //=================================== Audio ====================================

        if (PlayerPrefs.HasKey("Volume"))
        {
            VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
            am.SetFloat("masterVolume", VolumeSlider.value);
        }
        else
        {
            VolumeSlider.value = 100;
        }

        //==============================================================================
    }

    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }

    public void ContinueGame()
    {
        Debug.Log("Exit pressed!");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //======================== Настройки =========================
    public void SetRes()
    {
        Screen.SetResolution(res[ResolutionDropdown.value].width, res[ResolutionDropdown.value].height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", ResolutionDropdown.value);
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(QualitySettinsDropdown.value);
        PlayerPrefs.SetInt("Quality", QualitySettinsDropdown.value);
    }

    public void ScreenMode()
    {
        Screen.fullScreen = Fullscreen.isOn;
        if (Screen.fullScreen == true)
        {
            PlayerPrefs.SetInt("FullScreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 0);
        }
    }
    
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
        PlayerPrefs.SetFloat("Volume", sliderValue);
    }

    /*public void MuteVolume()
    {
        muted = MuteToggle.isOn;
        if (muted == true)
        {
            PlayerPrefs.SetInt("Mute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Mute", 0);
        }
    }*/
    //======================== Настройки =========================
}
