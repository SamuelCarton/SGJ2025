using UnityEngine;

public class Plant : MonoBehaviour, IDraggable
{
    public Plant_Data PlantData;
    public float Poids;
    public float HeavyMetalRatio;

    public float GetQuality()
    {
        return 1.0f;
    }

    public bool IsAPlant()
    {
        return true;
    }
}