using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbsUpLoadingScreen : MonoBehaviour
{
    public Animator animator;

    public GameObject targetCounter;
    public GameObject loadingScreenImage;
    public UiFadeout thumbsUpFadeout;
    public UiFadeout blackScreenFadeout;
    public bool gameHasStarted;

    public float fadeoutTime1;
    public float fadeoutTime2;

    void Start()
    {
        animator.SetBool("PlayThumbsUp", true);
        gameHasStarted = false;
    }

    public IEnumerator GameStart()
    {
        thumbsUpFadeout.FadeOut();
        yield return new WaitForSeconds(fadeoutTime1);
        blackScreenFadeout.FadeOut();
        yield return new WaitForSeconds(fadeoutTime2);
        targetCounter.SetActive(true);
        gameHasStarted = true;
        loadingScreenImage.SetActive(false);
    }
}
