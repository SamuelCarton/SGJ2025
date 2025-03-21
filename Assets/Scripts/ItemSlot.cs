using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public UnityEvent<IDraggable> onDrop;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition 
            = GetComponent<RectTransform>().anchoredPosition;
            
        IDraggable draggable = eventData.pointerDrag.GetComponent<IDraggable>();
        if (draggable == null)
        {
            return;
        } 
        onDrop.Invoke(draggable);
    }
}
