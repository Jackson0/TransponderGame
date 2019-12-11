using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    // Player movement parameters
    public float Speed = 5f;
    public float maxVelocityChange = 10f;
    public bool canJump = true;
    public float gravity = 10.0f;
    public float jumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public float rotateSpeed = 5f;
    // The layer that will be considered to be the ground
    public LayerMask isGround;
    
    // For the player object's rigidbody component
    private Rigidbody rb;
    private bool jumpButtonPressed = false;
    private Vector3 inputs = Vector3.zero;
    private Vector3 moveDirection;
    private bool isGrounded = false;
    private Transform groundChecker;
    Vector2 mouseRotation = Vector2.zero;

    

    // Variable thats gonna hold the camera
    Camera playerCam;

    // Mouse Cursor Stuff
    CursorLockMode lockMode;

    void Awake()
    {
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
        Cursor.visible = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
    }

    void Update()
    {
        // Moved the jump to Update insted of FixedUpdate due to 'Input Loss' phenomena, due to the way Fixed Update runs.
        // With high framerates there is no guarentee FixedUpdate will get called during a frame,
        // and GetButtonDown is only returned during the cycle of one frame

        if (Input.GetButtonDown("Jump") && !Pause_Menu.gameIsPaused)
        {
            jumpButtonPressed = true;
        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene(0);
        //}
    }

    

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(this.transform.position, GroundDistance, isGround, QueryTriggerInteraction.Ignore);
        PlayerWalkControl();
        PlayerLook();
       
    }

    void LateUpdate()
    {
       
       
    }

    

    private void PlayerLook()
    {
        // Player rotation (panning)
        mouseRotation.y = 0;
        mouseRotation.y += Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;
        //transform.Rotate(new Vector3(0, mouseRotation.y, 0));
        Quaternion yRotation = Quaternion.Euler(new Vector3(0, mouseRotation.y, 0));
        rb.MoveRotation(rb.rotation*yRotation);

        // Camer rotation (up&down)
        mouseRotation.x += -Input.GetAxisRaw("Mouse Y") * rotateSpeed * Time.deltaTime;

        //Clamp camera's rotation around the x so players neck don't break
        mouseRotation.x = Mathf.Clamp(mouseRotation.x, -89f, 89f);

        playerCam.transform.localEulerAngles = new Vector3(mouseRotation.x, 0, 0);
    }

    private void PlayerWalkControl()
    {
        if (isGrounded)
        {
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= Speed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);


            if (canJump && jumpButtonPressed)
            {
                jumpButtonPressed = false;
                rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }

            // We apply gravity manually for more tuning control
            rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
        }

       

    }

    private float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!!");
        if (other.gameObject.tag == "Lift")
        {
            rb.useGravity = false;
            rb.velocity = new Vector3 { x = 0, y = 0, z = 0 };
            transform.SetParent(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("UNTriggered!!");
        if (other.gameObject.tag == "Lift")
        {
            rb.useGravity = true;
            transform.parent = null;
        }
    }

    public void TeleportPlayer(Vector3 newPosition)
    {

        var spawnProximityCheck = new SpawnProximityCheck(newPosition);
 
        if (spawnProximityCheck.CanSpawnHere())
        {
            transform.position = spawnProximityCheck.validSpawnPoint();
        }
     
    }


    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        

        Vector3 drawPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Gizmos.DrawWireSphere(drawPosition, 0.5f);

        //Vector3 drawPosition = new Vector3(transform.position.x - offsetFromPlayerPos, transform.position.y, transform.position.z);
        //Gizmos.DrawWireSphere(drawPosition, 0.5f);
        //drawPosition = new Vector3(transform.position.x + offsetFromPlayerPos, transform.position.y, transform.position.z);
        //Gizmos.DrawWireSphere(drawPosition, 0.5f);
        //drawPosition = new Vector3(transform.position.x, transform.position.y - offsetFromPlayerPos, transform.position.z);
        //Gizmos.DrawWireSphere(drawPosition, 0.5f);
        //drawPosition = new Vector3(transform.position.x, transform.position.y + offsetFromPlayerPos, transform.position.z);
        //Gizmos.DrawWireSphere(drawPosition, 0.5f);
        //drawPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - offsetFromPlayerPos);
        //Gizmos.DrawWireSphere(drawPosition, 0.5f);
        //drawPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + offsetFromPlayerPos);
        //Gizmos.DrawWireSphere(drawPosition, 0.5f);
    }


}



