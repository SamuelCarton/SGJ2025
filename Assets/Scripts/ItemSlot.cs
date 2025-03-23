using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public UnityEvent<IDraggable> onDrop;
    
    public void OnDrop(PointerEventData eventData)
    {
        HighlightIDropTargetOnDrag.OnDragPlantEnd?.Invoke();
        IDraggable draggable = eventData.pointerDrag.GetComponent<IDraggable>();
        if (draggable == null || draggable.CanBeDragged() == false)
        {
            return;
        }
        if (eventData.pointerDrag == null)
        {
            return;
        }
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition 
            = GetComponent<RectTransform>().anchoredPosition;
        onDrop.Invoke(draggable);
    }
}
