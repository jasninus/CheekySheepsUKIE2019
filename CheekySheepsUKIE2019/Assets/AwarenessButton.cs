using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwarenessButton : MonoBehaviour
{
    [SerializeField] private Button awarenessButton;

    [SerializeField] private CanvasGroup[] uiElements;

    private uint PopUpIndex;


    //if you click a button spawn a pop up;
    //increase the index for the pop ups;
    //disable the button for a couple of seconds
    //increase the awareness points
    //instanciate new social media pop up
    //have a delay and then start fade out the pop up 
    // eventually move the pop up up 


    public void OnPressedButton()
    {
        //awarenesspoints+=200;
        awarenessButton.interactable = false;
        PopUpAnimation(uiElements[Random.Range(0, 15)]);
        StartCoroutine(WhateverYouWant());

    }

    IEnumerator WhateverYouWant ()
    {
        yield return new WaitForSeconds(4);
        awarenessButton.interactable = true;
    }

    public void FadeIn(CanvasGroup PopUp)
    {
        StartCoroutine(FadePopUp(PopUp, PopUp.alpha, 1));

    }
    public void FadeOut(CanvasGroup PopUp)
    {
        StartCoroutine(FadePopUp(PopUp, PopUp.alpha, 0));
    }
    public IEnumerator FadePopUp(CanvasGroup cg, float start, float end, float lerpTime = 1f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float PercentageComplete = timeSinceStarted / lerpTime;
        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            PercentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, PercentageComplete);
            cg.alpha = currentValue;

            if (PercentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

    }

    public IEnumerator MovePopUp()
    {

        yield return new WaitForEndOfFrame();
    }

    public void PopUpAnimation(CanvasGroup PopUp)
    {

        FadeIn(PopUp);
        StartCoroutine(DelayAnimation(PopUp));

    }

    public IEnumerator DelayAnimation(CanvasGroup PopUp)
    {
        yield return new WaitForSeconds(6);
        FadeOut(PopUp);
    }
   
}
