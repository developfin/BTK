using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageLoading : MonoBehaviour
{
    public Text[] Menu_Main_Text;
    public Text[] Menu_Lang_Text;
    public Text[] Menu_Settings_Text;
    public Text[] Menu_Play_Text;
    public Text[] Settings_General_Text;
    public Text[] Settings_Graphic_Text;
    public Text[] Settings_Audio_Text;

    public void UpdateText()
    {
        for (int i = 0; i < Menu_Main_Text.Length; i++) Menu_Main_Text[i].text = LangSystem.lng.main_menu_main[i];
        for (int a = 0; a < Menu_Lang_Text.Length; a++) Menu_Lang_Text[a].text = LangSystem.lng.main_menu_language[a];
        for (int b = 0; b < Menu_Settings_Text.Length; b++) Menu_Settings_Text[b].text = LangSystem.lng.main_menu_settings[b];
        for (int c = 0; c < Menu_Play_Text.Length; c++) Menu_Play_Text[c].text = LangSystem.lng.main_menu_play[c];
        for (int d = 0; d < Settings_General_Text.Length; d++) Settings_General_Text[d].text = LangSystem.lng.settings_general[d];
        for (int e = 0; e < Settings_Graphic_Text.Length; e++) Settings_Graphic_Text[e].text = LangSystem.lng.settings_graphic[e];
        for (int f = 0; f < Settings_Audio_Text.Length; f++) Settings_Audio_Text[f].text = LangSystem.lng.settings_audio[f];
    }
}
