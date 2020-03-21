using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Ray : MonoBehaviour
{
    public GameObject InventoryObj, Player, GrayPanel;
    private bool pause_on, inv_open;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv_open = !inv_open;
            OpenInventory();
        }

        
    }

    void OpenInventory()
    {
        if (inv_open)
        {
            pause_on = true;
            Pause();
            InventoryObj.SetActive(true);
        }
        else
        {
            pause_on = false;
            Pause();
            InventoryObj.SetActive(false);
        }
    }

    void Pause()
    {
        if (pause_on)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<Player_Controller>().enabled = false;
            GrayPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Player.GetComponent<Player_Controller>().enabled = true;
            GrayPanel.SetActive(false);
        }
    }
}
