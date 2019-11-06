using System;
using UnityEngine;

public class VolunteerType : MonoBehaviour
{
    public Action<float> updateEnergyUI, updateHealthUI;

    public float Energy
    {
        get => energy;
        private set
        {
            energy = value;
            updateEnergyUI?.Invoke(energy);
        }
    }

    public float Health
    {
        get => health;
        private set
        {
            health = value;
            updateHealthUI?.Invoke(health);
        }
    }

    protected float energy, health;
}