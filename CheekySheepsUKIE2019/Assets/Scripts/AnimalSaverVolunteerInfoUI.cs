using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalSaverVolunteerInfoUI : VolunteerInfoUI
{
    [SerializeField] private Text savingAnimalsText, savingAnimalsButtonText;

    private AnimalSaverVolunteer currentAnimalSaverVolunteer;

    public override void Activate(VolunteerType toDisplay)
    {
        base.Activate(toDisplay);

        currentAnimalSaverVolunteer = (AnimalSaverVolunteer)toDisplay;
        currentAnimalSaverVolunteer.updateSavingUI += UpdateAnimalSavingUI;
    }

    private void UpdateAnimalSavingUI(bool value)
    {
        savingAnimalsText.text = value ? "Yes" : "No";
        savingAnimalsButtonText.text = value ? "Stop saving animals" : "Start saving animals";
    }

    public void ToggleSavingAnimals()
    {
        currentAnimalSaverVolunteer?.ToggleSaving();
    }

    public override void Deactivate()
    {
        currentAnimalSaverVolunteer.updateSavingUI -= UpdateAnimalSavingUI;
        currentAnimalSaverVolunteer = null;
        base.Deactivate();
    }
}