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
    public Sprite Armadillo;
    public Sprite Cat;
    public Sprite Anteater;
    public Sprite Macaw;

    void Update ()
    {
        //for testing only as I don't know the requirements
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PopUpActivation();
        }
    }

    /*void PopUpActivate ()
    {
        PopUpBoxes.SetActive(true);
        PopUpState = true;
    }

    void PopUpDeactivate()
    { 
        float secondsLeft = 0;

        void Start() { StartCoroutine(DelayLoadLevel(5)); }
        Start();
        IEnumerator DelayLoadLevel(float seconds)
        {
            secondsLeft = seconds;
            do { yield return new WaitForSeconds(1); }
            while (--secondsLeft > 0);
            PopUpBoxes.SetActive(false);
            PopUpState = false;
        }
    }*/

    void PopUpActivation()
    {
        PopUpBoxes.SetActive(true);
        float secondsLeft = 0;

        void Start() { StartCoroutine(DelayLoadLevel(4)); }
        Start();
        IEnumerator DelayLoadLevel(float seconds)
        {
            secondsLeft = seconds;
            do { yield return new WaitForSeconds(1); }
            while (--secondsLeft > 0);
            PopUpBoxes.SetActive(false);
        }
    }

    /*void Start() { StartCoroutine(DelayLoadLevel(5)); }

    IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds;
        do { yield return new WaitForSeconds(1); }
        while (--secondsLeft > 0);
        
    }*/

    //Image AwarnessFrame;

    /*void Framer()
    {
        AwarnessFrame = GetComponent<Image>();
    }*/

    //int AniSwitch = 1;

    /*void AniSwitcher ()
    {

        /*PopVals variable;
        variable = PopVals.AniPicOne;
        switch (AniSwitch)
        {
            case 1:
                AniPicOne = I;
                //choose dolpine
                break;
            case 2:
                AniPicTwo = GetComponent//<Image>();
                //choose monkey
                break;
            case 3:
                AniPicThree = GetComponent//<Image>();
                //choose macaw
                break;
            case 4:
                AniPicFour = GetComponent//<Image>();
                //choose cat
                break;
        }
    }*/

    //changing dependant on what triggers each animal
     int AniNum = 0;

    void PicPicker ()
    {
        switch (AniNum)
        {
            case 0:
                this.gameObject.GetComponent<Image>().sprite = Armadillo;
                break;
            case 1:
                this.gameObject.GetComponent<Image>().sprite = Cat;
                break;
            case 2:
                this.gameObject.GetComponent<Image>().sprite = Anteater;
                break;
            case 3:
                this.gameObject.GetComponent<Image>().sprite = Macaw;
                break;
            default:
                this.gameObject.GetComponent<Image>().sprite = Armadillo;
                break;
        }
    }
}