using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBox : MonoBehaviour
{
    public enum PopVals
    {
        AniPicOne,
        AniPicTwo,
        AniPIcThree,
    }

    //public static bool PopUpState = false;
    public GameObject PopUpBoxes;
    public CanvasGroup PopUpBoxes1;
    public Image ImagetoSet;
    public Sprite Armadillo;
    public Sprite Cat;
    public Sprite Anteater;
    public Sprite Macaw;

    void Update ()
    {
        //for testing only as I don't know the requirements
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
            PicPicker(3);
           
            PopUpActivation();
            //FadeOut();
        //}
    }

    void PopUpActivation()
    {
        //PopUpBoxes.SetActive(true);
        //float secondsLeft = 0;
        //
        //void Start() { StartCoroutine(DelayLoadLevel(4)); }
        //Start();
        //IEnumerator DelayLoadLevel(float seconds)
        //{
        //    secondsLeft = seconds;
        //    do { yield return new WaitForSeconds(1); }
        //    while (--secondsLeft > 0);
        //    PopUpBoxes.SetActive(false);
        //}
        FadeIn(PopUpBoxes1);
        StartCoroutine(DelayAnimation(PopUpBoxes1));
    }

    //changing dependant on what triggers each animal
     

    void PicPicker (int AnimalIndex)
    {
        
        switch (AnimalIndex)
        {
            case 0:
                ImagetoSet.sprite = Armadillo;
                break;
            case 1:
                ImagetoSet.sprite = Cat;
                break;
            case 2:
                ImagetoSet.sprite = Anteater;
                break;
            case 3:
                ImagetoSet.sprite = Macaw;
                break;
            default:
                ImagetoSet.sprite = Armadillo;
                break;
        }
    }
    /*
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
        yield return new WaitForSeconds(15);
        awarenessButton.interactable = true;
    }*/


    public void FadeOut(CanvasGroup PopUp)
    {
        StartCoroutine(FadePopUp(PopUp, PopUp.alpha, 0));
    }
    public void FadeIn(CanvasGroup PopUp)
    {
        StartCoroutine(FadePopUp(PopUp, PopUp.alpha, 1));
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
    
   
    public void PopUpAnimation(CanvasGroup PopUp)
    {

        FadeIn(PopUp);
        StartCoroutine(DelayAnimation(PopUp));

    }

    public IEnumerator DelayAnimation(CanvasGroup PopUp)
    {
        yield return new WaitForSeconds(3);
        FadeOut(PopUp);
    }
   
}

