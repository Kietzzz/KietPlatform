using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float MoveSpeed;
    //private Rigidbody rb;
    public float JumpForce;

    private CharacterController controller;

    private Vector3 moveDicrection;
    public float gravityScale;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        /*rb.velocity = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * MoveSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        }
        */

        moveDicrection = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, 0, Input.GetAxis("Vertical") * MoveSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            moveDicrection.y = JumpForce;
        }
        moveDicrection.y = moveDicrection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDicrection*Time.deltaTime);

    }
}
