using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector2 rectTransform;
    private RectTransform rectTrans;

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
    }
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GameObject.Find("ItemImage").GetComponent<RectTransform>().anchoredPosition;
    }

}
