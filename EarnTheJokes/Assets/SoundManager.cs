using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource calm;
    public AudioSource dreamer;

    public bool inDream;

    void Update()
    {
        if(inDream)
        {
            if(dreamer.isPlaying == false)
            {
                dreamer.Play();
            }

            calm.Pause();

        }

        else
        {
            if (calm.isPlaying == false)
            {
                calm.Play();
            }

            dreamer.Pause();
        }
    }
}
