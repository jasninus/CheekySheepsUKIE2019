using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private ShopManagerScript managerScript;
    public float currentTime = 0f;
    public float startingTime = 20.0f;
    [SerializeField] public uint AmountOfResources;
    public Text text;

    private void Awake()
    {
        managerScript = GetComponent<ShopManagerScript>();
    }

    private void UpdateTimer()
    {
        if (managerScript.GetResources() >= AmountOfResources)
        {
            currentTime -= Time.deltaTime;
        }
        if (managerScript.GetResources() - 100 > AmountOfResources)
        {
            startingTime -= Time.deltaTime;
        }
    }

    private void IncrementResources()
    {
        AmountOfResources += 100;
    }

    public void UpdateText()
    {
        text.text = "Countdown: " + currentTime.ToString("0");
    }

    // Start is called before the first frame updates
    private void Start()
    {
        currentTime = startingTime;
        InvokeRepeating("IncrementResources", 1, 2);
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        UpdateText();
        UpdateTimer();
        if (currentTime <= 0.0f)
        {
            currentTime = startingTime;
        }
    }
}