using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Elements : MonoBehaviour
{
    [SerializeField]
    public GameObject ButtonsPanel;
    public Text text;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(ButtonsPanel.activeSelf == false)
            {
                ButtonsPanel.SetActive(true);
            }
        }
    }

    public void HideButtonsInv(object Button)
    {
        ButtonsPanel.SetActive(false);
        text.text = Button.ToString();
    }
}
