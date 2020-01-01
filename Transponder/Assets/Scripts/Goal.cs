using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    

    public static bool goalReached = false;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        goalReached = true;
    }
}
