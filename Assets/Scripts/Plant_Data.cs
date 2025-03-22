using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlantData", menuName = "SGJ2025/PlantData")]
public class Plant_Data : ScriptableObject
{
    public string plantName;
    public float decompositionTime; 
    public float fertilizerAmount; 
    public List<Sprite> plantSprites = new List<Sprite>();
    public Sprite SpriteFull;
    public float GrowingTime;

    [Header("Comestible")]
    public float ToxicRatioMax = 0.1f;
    public float WaterRatioMin = 0.3f;
    public float WaterRatioMax = 0.6f;
    public float LightTimeMin = 0.2f;
    public float LightTimeMax = 0.4f;
}