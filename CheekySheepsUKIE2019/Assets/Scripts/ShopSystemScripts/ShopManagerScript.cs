using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public static ShopManagerScript shopManagerScript;
    [SerializeField] private uint resources;
    public Text ResourcesText;

    public void AddResources(uint amount)
    {
        resources += amount;
        UpdateStoreUI();
    }

    public void SubractResources(uint amount)
    {
        resources -= amount;
        UpdateStoreUI();
    }

    public bool EnoughResources(uint amount) => amount <= resources;

    void UpdateStoreUI()
    {
        ResourcesText.text = "£ " + resources.ToString("N2");
    }

    // Start is called before the first frame update
    void Start()
    {
        shopManagerScript = this;
        UpdateStoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
