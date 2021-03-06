﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;
    

    [SerializeField]
    private List<GameObject> listOfLevels = new List<GameObject>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(GameObject GO)
    {
        for (int count = 0; count <= listOfLevels.Count() - 1; count++)
        {
            

            if (listOfLevels[count] == GO)
            {
                
                SceneManager.LoadScene(count + 1);
            }
        }
    }

    public void backToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Pause_Menu.gameIsPaused = false;
        Goal.goalReached = false;
    }

   public void ReceiveListOfLevels(List<GameObject> receivedListOfLevels)
    {
        // Copy list of levels;
        listOfLevels = receivedListOfLevels;
    }

}
