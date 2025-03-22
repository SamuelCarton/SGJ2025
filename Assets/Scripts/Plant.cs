using UnityEngine;

public class Plant : MonoBehaviour
{
    public Plant_Data PlantData;
    public float Poids;
    public float HeavyMetalRatio;

    public float GetQuality()
    {
        return 1.0f;
    }

}