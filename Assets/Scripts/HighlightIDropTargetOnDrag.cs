using System;
using Unity.VisualScripting;
using UnityEngine;

public class HighlightIDropTargetOnDrag : MonoBehaviour
{

    public static Action OnDragPlantStart;
    public static Action OnDragPlantEnd;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnDragPlantStart += Show;
        OnDragPlantEnd += Hide;
        Hide();
    }

    private void OnDestroy()
    {
        OnDragPlantStart -= Show;
        OnDragPlantEnd -= Hide;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
