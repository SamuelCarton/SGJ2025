using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static public ResourceManager Instance { get; private set; }

    public float compostAmount;
    
    public List<Plant> plants = new List<Plant>();
    
    public void Awake()
    {
        Instance = this;
    }
    
}