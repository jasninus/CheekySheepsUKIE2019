using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolunteerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed, yPosition;
    [SerializeField, Tooltip("The distance from the XZdestination at which movement will be considered complete")] private float sqrMovementTolerance;

    private const int RIGHT_MOUSE_BUTTON = 1;

    private Vector3 moveTarget;

    public bool moving;
    private bool awaitingMoveTarget;

    private Volunteer volunteer;

    private void Awake()
    {
        volunteer = GetComponent<Volunteer>();
    }

    private void Update()
    {
        if (volunteer.isSelected && Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON))
        {
            MoveToTarget(GetMouseGroundPosition());
        }
    }

    public void MoveToTarget(Vector3 XZdestination)
    {
        StopAllCoroutines();
        Vector3 destination = new Vector3(XZdestination.x, yPosition, XZdestination.z);
        Debug.Log($"MoveTarget is: {moveTarget}");
        StartCoroutine(Moving(destination));
        awaitingMoveTarget = false;
    }

    private IEnumerator Moving(Vector3 destination)
    {
        moving = true;
        yield return new WaitForFixedUpdate();

        while (Vector3.SqrMagnitude(destination - transform.position) > sqrMovementTolerance)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed);
            yield return new WaitForFixedUpdate();
        }

        moving = false;
        Debug.Log("Movement complete! I WALKED 500 MILES");
    }

    public void MoveToTarget(Transform XZTarget)
    {
        StopAllCoroutines();
        StartCoroutine(MovingToTransform(XZTarget));
    }

    private IEnumerator MovingToTransform(Transform target)
    {
        moving = true;
        yield return new WaitForFixedUpdate();

        while (Vector3.SqrMagnitude(target.position - transform.position) > sqrMovementTolerance)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, yPosition, target.position.z), movementSpeed);
            yield return new WaitForFixedUpdate();
        }

        moving = false;
    }

    private Vector3 GetMouseGroundPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit);

        if (hit.transform == null)
        {
            return transform.position;
        }

        return hit.transform.gameObject.layer == LayerMask.NameToLayer("River") ? transform.position : hit.point;
    }

    public void StopMoving()
    {
        moving = false;
        StopAllCoroutines();
    }

    //private void OnMouseDown()
    //{
    //    Debug.Log("I got clicked on!");
    //    awaitingMoveTarget = true;
    //}
}