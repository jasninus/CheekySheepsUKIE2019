using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolunteerType : MonoBehaviour
{
    [SerializeField] private GameObject infoUI;

    public GameObject GetInfoUI() => infoUI;
}