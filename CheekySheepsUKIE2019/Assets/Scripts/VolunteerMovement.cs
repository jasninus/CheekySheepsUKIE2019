using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolunteerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed, yPosition;
    [SerializeField, Tooltip("The distance from the XZdestination at which movement will be considered complete")] private float sqrMovementTolerance;

    private const int RIGHT_MOUSE_BUTTON = 1;

    private Vector3 moveTarget;

    private bool awaitingMoveTarget;

    private void Update()
    {
        //Debug.Log($"AwaitingMoveTarget: {awaitingMoveTarget}");

        if (awaitingMoveTarget && Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON))
        {
            MoveToTarget(GetMouseGroundPosition());
        }
    }

    private void MoveToTarget(Vector3 XZdestination)
    {
        StopAllCoroutines();
        Vector3 destination = new Vector3(XZdestination.x, yPosition, XZdestination.z);
        Debug.Log($"MoveTarget is: {moveTarget}");
        StartCoroutine(Moving(destination));
        awaitingMoveTarget = false;
    }

    private IEnumerator Moving(Vector3 destination)
    {
        while (Vector3.SqrMagnitude(destination - transform.position) > sqrMovementTolerance)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed);
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("Movement complete! I WALKED 500 MILES");
    }

    private Vector3 GetMouseGroundPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit);
        return hit.point;
    }

    private void OnMouseDown()
    {
        Debug.Log("I got clicked on!");
        awaitingMoveTarget = true;
    }
}