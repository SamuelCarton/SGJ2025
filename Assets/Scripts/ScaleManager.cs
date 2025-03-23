using System;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    public static ScaleManager Instance { get; private set; }
    
    [SerializeField] public Canvas canvas;

    private void Awake()
    {
        Instance = this;
    }
}
