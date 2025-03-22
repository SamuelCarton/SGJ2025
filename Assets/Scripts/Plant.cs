using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour, IDraggable
{
    public Plant_Data PlantData;
    public float Poids;
    public float HeavyMetalRatio;
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