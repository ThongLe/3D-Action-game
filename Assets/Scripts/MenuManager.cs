using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; set; }

    public GameObject Menu;
    public GameObject UI;

    public GameObject InGameMenu;
    public GameObject SettingsMenu;

    public bool isMenuOpen;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isMenuOpen)
        {
            UI.SetActive(false);
            Menu.SetActive(true);

            isMenuOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && isMenuOpen)
        {
            SettingsMenu.SetActive(false);
            InGameMenu.SetActive(true);
            UI.SetActive(true);
            Menu.SetActive(false);

            isMenuOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
