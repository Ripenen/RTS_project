using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public event Action<Vector3> OnClickLmb;
    public event Action<Vector3> OnClickRmb;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                OnClickLmb?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
                break;
            case PointerEventData.InputButton.Right:
                OnClickRmb?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
                break;
        }
    }
}