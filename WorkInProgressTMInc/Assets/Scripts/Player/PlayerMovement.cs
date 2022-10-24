 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    //keybinds
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public bool toggleSprint = true;

    public float moveSpeed, groundDrag;

    bool grounded;
    bool readyToJump = true;
    public LayerMask whatIsGround;

    public Transform orientation;

    float horizontalInput, verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        moveSpeed = PlayerStats.walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, PlayerStats.playerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
        SpeedControl();
        if(grounded){
            rb.drag = groundDrag;
        }else{
            rb.drag = 0;
        }
    }
    private void FixedUpdate() {
        MovePlayer();    
    }
    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (toggleSprint)
        {
            if(Input.GetKeyDown(sprintKey)&& grounded)
            {
                moveSpeed = PlayerStats.sprintSpeed;
            }
            if (Input.GetKeyUp(sprintKey))
            {
                moveSpeed = PlayerStats.walkSpeed;
            }
        }
        else
        {
            if (Input.GetKey(sprintKey))
            {
                moveSpeed = PlayerStats.sprintSpeed;
            }
            else
            {
                moveSpeed = PlayerStats.walkSpeed;
            }
        }
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), PlayerStats.jumpCooldown);
        }
    }
    private void MovePlayer(){
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * PlayerStats.airMultiplier, ForceMode.Force);
        }
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * PlayerStats.jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
