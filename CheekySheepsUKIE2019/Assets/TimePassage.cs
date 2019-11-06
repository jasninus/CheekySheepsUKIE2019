using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimePassage : MonoBehaviour
{
    private float secondsLeft = 0;
    void Start() {StartCoroutine(DelayLoadLevel(5));}

    IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds; 
        do {yield return new WaitForSeconds(1);}
        while (--secondsLeft > 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
