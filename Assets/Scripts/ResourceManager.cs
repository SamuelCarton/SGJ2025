using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static public ResourceManager Instance { get; private set; }
    public Action<float> OnCompostAmountChanged { get; set; }
    
    public float TotalMaterialInPot = 25.0f;

    public float compostAmount;
    
    public List<Plant> plants = new List<Plant>();

    public void Awake()
    {
        Instance = this;
    }

    public void AddCompost(float valComp)
    {
        compostAmount += valComp;
        OnCompostAmountChanged?.Invoke(compostAmount);
    }
}