using System.Collections.Generic;
using UnityEngine;

public class PotsManager : MonoBehaviour
{
    public static PotsManager Instance { get; private set; }
    
    [SerializeField] private GameObject canvas;

    void Awake()
    {
        Instance = this;
    }
    
    public List<Pot> pots;

    public Transform GetCanvas()
    {
        return canvas.transform;
    }
}