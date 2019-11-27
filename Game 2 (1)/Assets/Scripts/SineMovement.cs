using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public GameObject player;

    Vector3 startPos;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Mathf.Sin(Time.timeSinceLevelLoad);
        
        //transform.position = startPos + Vector3.up * distance;
        rb.MovePosition(startPos + Vector3.up * distance * 5);
        //rb.position = startPos + Vector3.up * distance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
            // player.transform.Translate(new Vector3(0,0.05f,0));
            Debug.Log("Called");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }

}
