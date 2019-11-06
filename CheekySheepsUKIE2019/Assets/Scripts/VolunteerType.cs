using System;
using UnityEngine;

public class VolunteerType : MonoBehaviour
{
    public Action<float> updateEnergyUI/*, updateHealthUI*/;

    public float Energy
    {
        get => energy;
        set
        {
            energy = value;
            updateEnergyUI?.Invoke(energy);

            if (energy <= 0)
            {
                Disband();
            }
        }
    }

    //public float Health
    //{
    //    get => health;
    //    private set
    //    {
    //        health = value;
    //        updateHealthUI?.Invoke(health);
    //    }
    //}

    [SerializeField] private float startingEnergy;
    protected float energy/*, health*/;

    protected virtual void Awake()
    {
        Energy = startingEnergy;
    }

    public virtual void UpdateAllUI()
    {
        updateEnergyUI?.Invoke(energy);
        //updateHealthUI?.Invoke(health);
    }

    public virtual void Disband()
    {
        Debug.Log($"{gameObject.name} is disbanding, goodbye cruel world");
        Destroy(gameObject);
    }
}