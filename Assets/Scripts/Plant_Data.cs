using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "SGJ2025/PlantData")]
public class Plant_Data : ScriptableObject
{
    public string plantName;
    public List<Sprite> plantSprites = new List<Sprite>();

    [Header("Quality")]
    public float HeavyMetalMinRatio;
    
}