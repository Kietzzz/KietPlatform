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

    
    void LateUpdate()
    {
        /*rb.velocity = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * MoveSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        }
        */

        //moveDicrection = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, moveDicrection.y, Input.GetAxis("Vertical") * MoveSpeed);
        float yStore = moveDicrection.y;
        moveDicrection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDicrection = moveDicrection.normalized * MoveSpeed;
        moveDicrection.y = yStore;

        //nhay
        if (controller.isGrounded)
        {
            moveDicrection.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                
                moveDicrection.y = JumpForce;
            }
        }
        moveDicrection.y = moveDicrection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDicrection * Time.deltaTime);

    }

    
}
