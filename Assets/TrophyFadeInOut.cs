using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyFadeInOut : MonoBehaviour
{
    public Image trophy;

    public bool fadeTrophy;
    public bool fadeToBlack;
    public bool fadeToLight;

    public float fadeTime;

    [SerializeField] Color startingColor;
    [SerializeField] Color endingColor;

    private void Start()
    {
        //fadeTrophy = true;
        fadeToLight = false;
        fadeToBlack = true;
    }

    private void Update()
    {
       //if (fadeTrophy)
       // {
            if (trophy.color == startingColor)
            {
                fadeToBlack = true;
                fadeToLight = false;
            }

            if (trophy.color == endingColor)
            {
                fadeToBlack = false;
                fadeToLight = true;
            }

            if (fadeToBlack)
                FadeToBlack();

            if (fadeToLight)
                FadeToLight();
       // }

       // if (!fadeTrophy)
           // trophy.color = Color.white;
    }
    void FadeToBlack()
    {
        trophy.color = Color.Lerp(startingColor, endingColor, Mathf.PingPong(Time.time, fadeTime));
    }

    void FadeToLight()
    {
        trophy.color = Color.Lerp(endingColor, startingColor, Mathf.PingPong(Time.time, fadeTime));

    }
}

