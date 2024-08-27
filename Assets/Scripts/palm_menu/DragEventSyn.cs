using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragEventSyn : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    public ScrollRect parentScrollRect;

    void Start()
    {
        if (parentScrollRect == null)
        {
            parentScrollRect = GetComponentInParent<ScrollRect>();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        parentScrollRect.OnEndDrag(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentScrollRect.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        parentScrollRect.OnDrag(eventData);
    }
}