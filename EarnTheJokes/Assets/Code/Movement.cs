using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpHeight;
    public float runSpeed;
    public bool isGrounded;

    public float gravityincrease;
    private float gravityCounter;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(isGrounded)
        {
            transform.Translate(Vector3.right * horizontal * runSpeed * Time.deltaTime);
            gravityCounter = 0;
        }

        else
        {
            gravityCounter += gravityincrease * Time.deltaTime;
            transform.Translate(Vector3.down * gravityincrease * Time.deltaTime);
        }


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight * Time.deltaTime, ForceMode.Impulse);
        }

    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
