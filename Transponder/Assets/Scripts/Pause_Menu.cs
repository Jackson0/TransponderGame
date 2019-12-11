using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{

    



    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    private bool tickOnce = false;

    // Mouse Cursor Stuff
    CursorLockMode lockMode;

    // Update is called once per frame
    private void Update()
    {
       
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

       

    }

    private void LateUpdate()
    {
        if (tickOnce)
        {
            gameIsPaused = false;
            tickOnce = false;
        }
    }

    void Pause()
    {
        lockMode = CursorLockMode.None;
        Cursor.lockState = lockMode;
        Cursor.visible = true;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {

        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
        Cursor.visible = false;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //gameIsPaused = false;
        tickOnce = true;
    }

    public void backToMainMenu()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
