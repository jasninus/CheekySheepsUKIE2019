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
    public Image ImagetoSet;
    public Sprite Armadillo;
    public Sprite Cat;
    public Sprite Anteater;
    public Sprite Macaw;

    void Update ()
    {
        //for testing only as I don't know the requirements
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PicPicker();
            PopUpActivation();
        }
    }

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

    //changing dependant on what triggers each animal
     int AniNum = 0;

    void PicPicker ()
    {
        int AniNum = 0;
        switch (AniNum)
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
}