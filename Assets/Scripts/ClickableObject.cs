using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public event Action<Vector3> ClickLmb;
    public event Action<Vector3> ClickRmb;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                ClickLmb?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
                break;
            case PointerEventData.InputButton.Right:
                ClickRmb?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
                break;
        }
    }
}