using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolunteerInfoUI : MonoBehaviour
{
    public virtual void Activate(VolunteerType toDisplay)
    {
        gameObject.SetActive(true);
    }
}