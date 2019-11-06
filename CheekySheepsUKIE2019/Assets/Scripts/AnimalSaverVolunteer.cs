using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSaverVolunteer : VolunteerType
{
    public static List<Animal> animals = new List<Animal>();
    [HideInInspector] public Animal currentlySaving;

    [SerializeField] public float sqrSavingRange;

    public Action<bool> updateSavingUI;

    private VolunteerMovement movement;

    private bool isSaving;

    public bool IsSaving
    {
        get => isSaving;
        set
        {
            isSaving = value;
            updateSavingUI?.Invoke(isSaving);

            if (IsSaving)
            {
                movement.StopMoving();
            }

            if (currentlySaving)
            {
                currentlySaving.StopSaving();
            }

            currentlySaving = null;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        movement = GetComponent<VolunteerMovement>();
    }

    public override void UpdateAllUI()
    {
        base.UpdateAllUI();
        updateSavingUI?.Invoke(IsSaving);
    }

    public void ToggleSaving()
    {
        IsSaving = !IsSaving;
    }

    private void FixedUpdate()
    {
        if (IsSaving)
        {
            if (movement.moving)
            {
                IsSaving = false;
            }

            if (!currentlySaving)
            {
                float minDis = Mathf.Infinity;
                Animal closestAnimal = null;
                foreach (Animal animal in animals)
                {
                    float dis = Vector3.SqrMagnitude(animal.transform.position - transform.position);
                    if (dis < minDis)
                    {
                        minDis = dis;
                        closestAnimal = animal;
                    }
                }

                if (minDis <= sqrSavingRange)
                {
                    closestAnimal.StartSaving(this);
                    currentlySaving = closestAnimal;
                }
            }
        }
    }
}