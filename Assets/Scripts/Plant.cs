using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour, IDraggable
{
    public Plant_Data PlantData;
    public float Poids;
    public float ToxicRatio = 0.0f;
    public float WaterRatio = 0.0f;
    public float LightTime = 0.0f;
    
    [SerializeField] private Image plantImage;

    public float GetQuality()
    {
        return 1.0f;
    }

    public bool IsAPlant()
    {
        return true;
    }

    public void SetSprite(Sprite plantDataPlantSprite)
    {
        plantImage.sprite = plantDataPlantSprite;
    }
}