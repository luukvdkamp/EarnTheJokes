using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelButton : MonoBehaviour
{
    public DateButtons dateButtons;
    public int dateStatusValue;
    public Transform playerPosition;
    public GameObject player;
    public CinemachineVirtualCamera cam;
    public GameObject canvas;
    public GameObject scheldwoordCanvas;
    public SoundManager soundManager;

    public void Button()
    {
        dateButtons.dateStatus += dateStatusValue;
        player.transform.position = playerPosition.position;
        cam.Follow = player.transform;
        player.SetActive(true);
        canvas.SetActive(false);
        scheldwoordCanvas.SetActive(true);
        soundManager.inDream = true;
    }
}
