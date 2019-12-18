using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainMenu : MonoBehaviour
{
    CursorLockMode lockMode;

    void Awake()
    {
        lockMode = CursorLockMode.None;
        Cursor.lockState = lockMode;
        Cursor.visible = true;
    }


    // Moved sceneloading to MySceneManager
}
