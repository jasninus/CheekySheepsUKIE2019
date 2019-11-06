using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolunteerInfoUI : MonoBehaviour
{
    [SerializeField] protected Text energyText, healthText;

    protected VolunteerType currentToDisplay;

    public virtual void Activate(VolunteerType toDisplay)
    {
        toDisplay.updateEnergyUI += UpdateEnergyUI;
        //toDisplay.updateHealthUI += UpdateHealthUI;
        currentToDisplay = toDisplay;
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        currentToDisplay.updateEnergyUI -= UpdateEnergyUI;
        //currentToDisplay.updateHealthUI -= UpdateHealthUI;
        currentToDisplay = null;
        gameObject.SetActive(false);
    }

    protected void UpdateEnergyUI(float value) => energyText.text = value.ToString();

    //protected void UpdateHealthUI(float value) => healthText.text = value.ToString();
}