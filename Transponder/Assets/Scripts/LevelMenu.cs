using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
/*
 * On click event of button attached to, invokes LoadLevel in MySceneManager
 */

    Button button;
    MySceneManager mySceneManager;

    // Start is called before the first frame update
    void Start()
    {
        mySceneManager = FindObjectOfType<MySceneManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        //Debug.Log(gameObject.name);
        mySceneManager.LoadLevel(gameObject);
    }
}
