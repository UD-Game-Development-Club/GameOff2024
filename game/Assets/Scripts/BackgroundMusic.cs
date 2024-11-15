using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundMusic : MonoBehaviour
{
    // reference to all music clips and audio sources
    public AudioSource audioSourceIntro;
    public AudioSource audioSourcePast;
    public AudioSource audioSourcePresent;

    // reference gameInput to swap music tacks anytime time travel button is pressed
    [SerializeField] private GameInput gameInput;
    const float FADE_TIME_SECONDS = 1;
    bool presentTime = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    {
        // get intro length and play intro
        StartCoroutine(PlayMusic(audioSourceIntro.clip.length));
    } // end Start

    // Update is called once per frame
    void Update()
    {
        if (gameInput.GetInteractClick())
        {
            if (presentTime == true) {
                StartCoroutine(FadeIn(audioSourcePast));
                StartCoroutine(FadeOut(audioSourcePresent));
                presentTime = false;
            }
            else {
                StartCoroutine(FadeIn(audioSourcePresent));
                StartCoroutine(FadeOut(audioSourcePast));
                presentTime = true;
            }
        }
    } // end Update

    IEnumerator PlayMusic(float introLength)
    {
        // wait intro length
        yield return new WaitForSeconds(introLength - 1);

        // start past / present songs and delete intro source
        audioSourcePast.Play();
        audioSourcePresent.Play();
    } // end PlayMusic

    IEnumerator FadeOut(AudioSource source) 
    {
        float timeElapsed = 0;

        while (source.volume > 0) 
        {
            source.volume = Mathf.Lerp(1, 0, timeElapsed / FADE_TIME_SECONDS);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        float delay = 2;
        yield return new WaitForSeconds(delay);
    } // end FadeOut

    IEnumerator FadeIn(AudioSource source) 
    {
        float timeElapsed = 0;

        while (source.volume < 1) 
        {
            source.volume = Mathf.Lerp(0, 1, timeElapsed / FADE_TIME_SECONDS);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    } // end FadeIn
}
