using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private float alphaOnDrag = 1f;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        HighlightIDropTargetOnDrag.OnDragPlantStart?.Invoke();
        IDraggable draggable = eventData.pointerDrag.GetComponent<IDraggable>();
        if (draggable == null || draggable.CanBeDragged() == false)
        {
            return;
        }
        Plant plant = eventData.pointerDrag.GetComponent<Plant>();
        if (plant != null)
        {
            plant.SetSprite(plant.PlantData.SpriteFull);
        }
            
        canvasGroup.alpha = alphaOnDrag;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        HighlightIDropTargetOnDrag.OnDragPlantEnd?.Invoke();
        IDraggable draggable = eventData.pointerDrag.GetComponent<IDraggable>();
        if (draggable == null || draggable.CanBeDragged() == false)
        {
            return;
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        IDraggable draggable = eventData.pointerDrag.GetComponent<IDraggable>();
        if (draggable == null || draggable.CanBeDragged() == false)
        {
            return;
        }
        rectTransform.anchoredPosition += eventData.delta / ScaleManager.Instance.canvas.scaleFactor;
    }
}
