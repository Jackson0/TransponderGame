using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;

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

    public void LoadLevel()
    {
        
        if (EventSystem.current.currentSelectedGameObject.name == "Tutorial Button")
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Level 1")
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    public void backToMainMenu()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Pause_Menu.gameIsPaused = false;
    }
}
