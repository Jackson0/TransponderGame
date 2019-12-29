using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause_Menu : MonoBehaviour
{

    
    // CONSTRUCTOR
    //public Pause_Menu()
    //{
    //    Debug.Log("Fresh Pause_Menu object");
    //}

    [NonSerialized]
    public static bool gameIsPaused = false;
    

    public GameObject pauseMenuUI;
    public GameObject goalReached;
    

    private bool tickOnce = false;

    // Mouse Cursor Stuff
    CursorLockMode lockMode;

    private void Awake()
    {
        //Debug.Log(gameIsPaused);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Goal.goalReached)
        {
            GoalReached();
        }

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

    void GoalReached()
    {
        lockMode = CursorLockMode.None;
        Cursor.lockState = lockMode;
        Cursor.visible = true;

        goalReached.SetActive(true);
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

    
}
