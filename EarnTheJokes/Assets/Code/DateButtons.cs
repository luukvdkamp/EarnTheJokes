using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateButtons : MonoBehaviour
{
    public int dateStatus; // - is angry, + is happy
    public Image image;
    public Slider slider;

    public Texture2D normal;

    public Texture2D happy;
    public Texture2D superHappy;
    public Texture2D heelSuperHappy;

    public Texture2D angry;
    public Texture2D superAngry;
    public Texture2D heelSuperAngry;

    public Image blackBackground;
    public float fadeDuration;
    public GameObject gameOverCanvas;
    public GameObject endingCanvas;

    public void Update()
    {
        //bug
        if(dateStatus < -3)
        {
            dateStatus = -3;
        }

        else if(dateStatus > 3)
        {
            dateStatus = 3;
        }
        //bug

        if(dateStatus == 0)
        {

            Sprite sprite = Sprite.Create(normal, new Rect(0, 0, normal.width, normal.height), new Vector2(0.5f, 0.5f));

            // Assign the Sprite to the Image component
            image.sprite = sprite;
            slider.value = 0;
        }

        else if(dateStatus == 1)
        {
            Sprite sprite = Sprite.Create(happy, new Rect(0, 0, normal.width, normal.height), new Vector2(0.5f, 0.5f));

            // Assign the Sprite to the Image component
            image.sprite = sprite;
            slider.value = 1;
        }

        else if(dateStatus == 2)
        {
            Sprite sprite = Sprite.Create(superHappy, new Rect(0, 0, normal.width, normal.height), new Vector2(0.5f, 0.5f));

            // Assign the Sprite to the Image component
            image.sprite = sprite;
            slider.value = 2;
        }
        
        else if(dateStatus == 3)
        {
            Sprite sprite = Sprite.Create(heelSuperHappy, new Rect(0, 0, normal.width, normal.height), new Vector2(0.5f, 0.5f));

            // Assign the Sprite to the Image component
            image.sprite = sprite;
            slider.value = 3;

            EndingScene();
        }

        else if(dateStatus == -1)
        {
            Sprite sprite = Sprite.Create(angry, new Rect(0, 0, normal.width, normal.height), new Vector2(0.5f, 0.5f));

            // Assign the Sprite to the Image component
            image.sprite = sprite;
            slider.value = -1;
        }

        else if(dateStatus == -2)
        {
            Sprite sprite = Sprite.Create(superAngry, new Rect(0, 0, normal.width, normal.height), new Vector2(0.5f, 0.5f));

            // Assign the Sprite to the Image component
            image.sprite = sprite;
            slider.value = -2;
        }

        else if(dateStatus == -3)
        {
            Sprite sprite = Sprite.Create(heelSuperAngry, new Rect(0, 0, normal.width, normal.height), new Vector2(0.5f, 0.5f));

            // Assign the Sprite to the Image component
            image.sprite = sprite;
            slider.value = -3;

            GameOverScene();
        }


    }

    void EndingScene()
    {
        StartCoroutine(FadeInImageAndOpenEnding());
    }

    void GameOverScene()
    {
        StartCoroutine(FadeInImageAndOpenGameOver());
    }

    IEnumerator FadeInImageAndOpenEnding()
    {
        float currentAlpha = blackBackground.color.a;
        float targetAlpha = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, elapsedTime / fadeDuration);
            blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, targetAlpha);
        endingCanvas.SetActive(true);
    }

    IEnumerator FadeInImageAndOpenGameOver()
    {
        float currentAlpha = blackBackground.color.a;
        float targetAlpha = 1f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, elapsedTime / fadeDuration);
            blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, newAlpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, targetAlpha);
        gameOverCanvas.SetActive(true);
    }

}
