using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCloud : MonoBehaviour
{
    public float lifeTime;
    private float lifeCounter;

    void Update()
    {
        lifeCounter += Time.deltaTime;
        if(lifeCounter > lifeTime)
        {
            gameObject.SetActive(false);
            lifeCounter = 0;
        }
    }
}
