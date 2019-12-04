using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    CursorLockMode lockMode;

    void Awake()
    {
        lockMode = CursorLockMode.None;
        Cursor.lockState = lockMode;
        Cursor.visible = true;
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
}
