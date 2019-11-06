using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsPage : MonoBehaviour
{
    public void ChairtyOne()
    {
        //TestEnum variable;
        //variable = TestEnum.Value1;

        //if (variable == TestEnum.Value2)
        //{
        //    // DO something
        //}

        Debug.Log("Test Link One");
        Application.OpenURL("https://www.rainforest-alliance.org/");
    }

    public void Chairtytwo()
    {
        Debug.Log("Test Link Two");
        Application.OpenURL("https://www.sosamazonia.org.br/conteudo/");
    }

    public void ChairtyThree()
    {
        Debug.Log("Test Link Three");
        Application.OpenURL("https://teamtrees.org/");
    }

    public void ChairtyFour()
    {
        Debug.Log("Test Link Four");
        Application.OpenURL("https://rainforestfoundation.org/10-things-you-can-do-save-the-rainforest/");
    }

    public void BackToMainMenu() { SceneManager.LoadScene("Menu"); }
}

//public enum TestEnum
//{
//    Value1,
//    Value2,
//    Value3,
//    PoopFart
//}
