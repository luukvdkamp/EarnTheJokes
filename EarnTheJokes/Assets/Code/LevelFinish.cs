using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelFinish : MonoBehaviour
{
    public GameObject player;
    public CinemachineVirtualCamera cam;
    public GameObject camPosition;
    public Transform camPositionLocation;
    public GameObject canvas;
    public GameObject scheldCanvas;
    public Spawning spawning;
    public SoundManager soundManager;
    public DateButtons dateButtons;
    public int dateStatusValue;
    public AudioSource happy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.SetActive(true);
            cam.Follow = null;
            camPosition.transform.position = camPositionLocation.transform.position;
            canvas.SetActive(true);

            List<GameObject> myList = spawning.scheldwoordenList;
            foreach (GameObject obj in myList)
            {
                Destroy(obj);
            }

            dateButtons.dateStatus += dateStatusValue;
            scheldCanvas.SetActive(false);
            soundManager.inDream = false;
            happy.Play();
        }
    }
}
