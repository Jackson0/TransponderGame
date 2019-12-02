using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBob : MonoBehaviour
{

    private Vector3 currentPlayerPos;
    private Vector3 currentGunPos;


    public float bobMagnitude = 0.1f;
    public float bobbingSpeed = 0.1f;


    private void Start()
    {
        currentPlayerPos = transform.root.position;
        currentGunPos = transform.localPosition;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      

        if (areWeMoving())
        {
           
            float distance = Mathf.Sin(Time.timeSinceLevelLoad * bobbingSpeed * Time.deltaTime);
            //transform.position = startPos + Vector3.up * distance;
            transform.localPosition = new Vector3(currentGunPos.x, currentGunPos.y + (distance * bobMagnitude), currentGunPos.z);
            
            //rb.position = startPos + Vector3.up * distance;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    bool areWeMoving()
    {
        var newPos = transform.root.position;
        if (newPos.x != currentPlayerPos.x || newPos.z != currentPlayerPos.z)
        {
            currentPlayerPos = newPos;
            return true;
        }

        return false;
    }
}
