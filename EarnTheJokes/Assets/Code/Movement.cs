using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public float jumpHeight;
    public float runSpeed;
    public float runAirSpeed;
    public bool isGrounded;

    public float gravityincrease;
    private float gravityCounter;

    private void Update()
    {
        //domme bug fix unity moment
        transform.localRotation = new Quaternion();

        float horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal != 0)
        {
            animator.SetBool("walking", true);
        }

        else
        {
            animator.SetBool("walking", false);
        }

        if(isGrounded)
        {
            transform.Translate(Vector3.right * horizontal * runSpeed * Time.deltaTime);
            gravityCounter = 0;
        }

        else
        {
            gravityCounter += gravityincrease * Time.deltaTime;
            transform.Translate(Vector3.down * gravityincrease * Time.deltaTime);

            transform.Translate(Vector3.right * horizontal * runAirSpeed * Time.deltaTime);
        }


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight * Time.deltaTime, ForceMode.Impulse);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
