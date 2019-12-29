using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsRegister : MonoBehaviour
{
    /*
     * Manually populates Levels into list. 
     * As soon as we are on main menu (Start of game or returning from level) this list gets copied to MySceneManager for further processing.
     */

    public List<GameObject> listOfLevels;

    MySceneManager mySceneManager;  


    // Start is called before the first frame update
    void Start()
    {
        mySceneManager = FindObjectOfType<MySceneManager>();
        mySceneManager.ReceiveListOfLevels(listOfLevels);
    }

}
