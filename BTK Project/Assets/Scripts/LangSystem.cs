using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LangSystem : MonoBehaviour
{
    public LanguageLoading TranslateTextScript;
    public GameObject LangPanel;
    public GameObject MenuPanel;
    private string json;
    public static lang lng = new lang();
    private int langIndex;
    private string[] langArray = {"ru_RU", "en_US"};

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            if(Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
            {
                PlayerPrefs.SetString("Language", "ru_RU");
            }
            else
            {
                PlayerPrefs.SetString("Language", "en_US");
            }
        }
        else
        {
            LangPanel.SetActive(false);
            MenuPanel.SetActive(true);
        }
        LangLoad();
    }
    void LangLoad()
    {
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");
        lng = JsonUtility.FromJson<lang>(json);
    }

    public void RU_Lang()
    {
        langIndex = 0;
        PlayerPrefs.SetString("Language", langArray[langIndex]);
        LangLoad();
    }

    public void ENG_Lang()
    {
        langIndex = 1;
        PlayerPrefs.SetString("Language", langArray[langIndex]);
        LangLoad();
    }
}

public class lang
{
    public string[] main_menu_main;
    public string[] main_menu_language;
    public string[] main_menu_settings;
    public string[] main_menu_play;
    public string[] settings_general;
    public string[] settings_graphic;
    public string[] settings_audio;
}
