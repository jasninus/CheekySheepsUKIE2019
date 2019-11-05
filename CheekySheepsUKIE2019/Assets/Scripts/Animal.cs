using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private float moveDistance, movementSpeed, timeBetweenMovement, sqrMoveTolerance, yPosition, saveTime;

    private AnimalSaverVolunteer savingVolunteer;

    private bool isBeingSaved;

    private void Start()
    {
        AnimalSaverVolunteer.animals.Add(this);
        StartCoroutine(MovingTo(GetNextMovementTarget()));
    }

    /// <summary>
    /// Endlessly recursive
    /// </summary>
    private IEnumerator MovingTo(Vector3 target)
    {
        while (new Vector2(target.x - transform.position.x, target.z - transform.position.z).sqrMagnitude > sqrMoveTolerance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed);
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(timeBetweenMovement);
        StartCoroutine(MovingTo(GetNextMovementTarget()));
    }

    private Vector3 GetNextMovementTarget()
    {
        uint dir = (uint)Random.Range(0, 4);

        switch (dir)
        {
            case 0:
                return new Vector3(moveDistance, yPosition, 0);

            case 1:
                return new Vector3(0, yPosition, moveDistance);

            case 2:
                return new Vector3(-moveDistance, yPosition, 0);

            case 3:
                return new Vector3(0, yPosition, -moveDistance);

            default:
                return Vector3.zero;
        }
    }

    public void StartSaving(AnimalSaverVolunteer volunteer)
    {
        StopAllCoroutines();
        savingVolunteer = volunteer;
        StartCoroutine(DelayingSave(saveTime));
    }

    private IEnumerator DelayingSave(float delay)
    {
        isBeingSaved = true;
        yield return new WaitForSeconds(delay);
        Save();
    }

    private void Save()
    {
        Debug.Log("Yay! I got saved");
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isBeingSaved)
        {
            if (!savingVolunteer.IsSaving || savingVolunteer.currentlySaving != this || Vector3.SqrMagnitude(transform.position - savingVolunteer.transform.position) > savingVolunteer.sqrSavingRange)
            {
                StopSaving();
            }
        }
    }

    public void StopSaving()
    {
        StopAllCoroutines();
        StartCoroutine(MovingTo(GetNextMovementTarget()));
        isBeingSaved = false;
    }

    private void OnDisable()
    {
        AnimalSaverVolunteer.animals.Remove(this);
    }
}