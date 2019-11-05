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

    int AniSwitch = 1;
    
    void AniSwitcher ()
    {

        PopVals variable;
        variable = PopVals.AniPicOne;
        switch (AniSwitch)
        {
            case 1:
                AniPicOne = GetComponent<Image>();
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
    }
          
}