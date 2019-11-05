using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    ShopManagerScript shopManagerScript;
    [SerializeField] private uint resources;
    public Text ResourcesText;

    private uint Resources
    {
        get => resources;
        set
        {
            resources = value;
            UpdateStoreUI();
        }
    }

    public uint GetResources()
    {
        return resources;
    }
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
        ResourcesText.text = "Awarnes " + resources.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        shopManagerScript = this;
        UpdateStoreUI();
        InvokeRepeating("IncrementAwareness", 1, 1);
    }

    private void IncrementAwareness()
    {
        Resources += (uint)Random.Range(25, 100);
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateStoreUI();
    }
}
