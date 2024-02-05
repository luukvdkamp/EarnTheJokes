using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelFinish : MonoBehaviour
{
    public Movement movement;
    public CinemachineVirtualCamera cam;
    public GameObject camPosition;
    public Transform camPositionLocation;
    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            movement.enabled = false;
            cam.Follow = null;
            camPosition.transform.position = camPositionLocation.transform.position;
            canvas.SetActive(true);
        }
    }
}
