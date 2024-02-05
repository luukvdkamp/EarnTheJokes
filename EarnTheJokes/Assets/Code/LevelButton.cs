using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public DateButtons dateButtons;
    public int dateStatusValue;
    public int levelDifficulty; // 1 == easy, 2 == medium, 3 == hard

    public void Button()
    {
        dateButtons.dateStatus += dateStatusValue;
    }
}
