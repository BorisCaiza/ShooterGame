using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject pauseMenu;
    public Button exitButton;
    
    
    private void Awake()
    {
        pauseMenu.SetActive(false);
        exitButton.onClick.AddListener(ExitGame);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          //  Cursor.visible = true;
           // Cursor.lockState = CursorLockMode.None;
            
            
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            
        }
    }

    private void ExitGame()
    {
        print("Ejecución Finalizada");
        Application.Quit();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
      //  Cursor.visible = false;
       // Cursor.lockState = CursorLockMode.Locked;
    }
}
