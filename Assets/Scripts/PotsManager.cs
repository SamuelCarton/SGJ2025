using System.Collections.Generic;
using UnityEngine;

public class PotsManager : MonoBehaviour
{
    public static PotsManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    
    public List<Pot> pots;
}