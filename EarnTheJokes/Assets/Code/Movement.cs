using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    public DateButtons dateButtons;
    public Animator animator;
    public float jumpHeight;
    public float runSpeed;
    public float runAirSpeed;
    public bool isGrounded;

    public float gravityincrease;
    private float gravityCounter;
    public bool hitByScheldwoord;

    public Movement movement;
    public CinemachineVirtualCamera cam;
    public GameObject camPosition;
    public Transform camPositionLocation;
    public GameObject canvas;
    public GameObject scheldCanvas;
    public SoundManager soundManager;
    public GameObject wordCloud;


    //niet vullen
    public GameObject scheldwoord;

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

        if(hitByScheldwoord)
        {
            wordCloud.SetActive(true);
            dateButtons.dateStatus--;
            cam.Follow = null;
            camPosition.transform.position = camPositionLocation.transform.position;
            canvas.SetActive(true);
            List<GameObject> myList = scheldwoord.GetComponent<Scheldwoord>().spawning.scheldwoordenList;
            foreach (GameObject obj in myList)
            {
                Destroy(obj);
            }

            scheldCanvas.SetActive(false);
            hitByScheldwoord = false;

            soundManager.inDream = false;
            gameObject.SetActive(false);
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
