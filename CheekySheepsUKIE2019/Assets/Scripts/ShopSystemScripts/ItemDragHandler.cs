using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector2 rectTransform;
    private RectTransform rectTrans;

    [SerializeField] private VolunteerRole role;

    private void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.position = rectTransform;
        rectTrans.anchoredPosition = rectTransform;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit);
        hit.transform.GetComponent<Volunteer>()?.UpgradeTo(role);
    }
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GameObject.Find("ItemImage").GetComponent<RectTransform>().anchoredPosition;
    }

}
