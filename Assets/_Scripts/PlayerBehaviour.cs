using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementForce;
    public Rigidbody rigidbody;
    public bool isGrounded;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame - once every 16.666ms
    //1000ms for each second
    //approximately updates 60 times per second = 60fps
    void Update()
    {
        if (isGrounded) { 
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                //move right
                rigidbody.AddForce(Vector3.right * movementForce);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                //move left
                rigidbody.AddForce(Vector3.left * movementForce);
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                //move forward
                rigidbody.AddForce(Vector3.forward * movementForce);
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                //move back
                rigidbody.AddForce(Vector3.back * movementForce);
            }
            if (Input.GetAxisRaw("Jump") > 0)
            {
                //jump
                rigidbody.AddForce(Vector3.up * jumpForce);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
