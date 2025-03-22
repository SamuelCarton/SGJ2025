using UnityEngine;
using UnityEngine.UI;

public enum hydratationLevel {undeHydrated, overHydrated, hydrated}
public enum lightLevel {underExposed, overExposed, exposed}
public class Plant : MonoBehaviour, IDraggable
{
    public Plant_Data PlantData;
    public float Weight;
    public float ToxicRatio = 0.0f;
    public float WaterRatio = 0.0f;
    public float LightTime = 0.0f;
    public bool isScanned = false;
    public bool isComestible = false; 
    
    [SerializeField] private Image plantImage;
    private bool _canBeDragged = false;

    public float GetQuality()
    {
        return 1.0f;
    }

    public bool IsAPlant()
    {
        return true;
    }

    public bool CanBeDragged()
    {
        return _canBeDragged;
    }

    public void SetSprite(Sprite plantDataPlantSprite)
    {
        plantImage.sprite = plantDataPlantSprite;
    }

    public hydratationLevel HydratationLevel(){ //retourne -1 si soushyrigué, 0 si c'est irrigué comme il faut et 1 si trop d'eau 

        if(this.WaterRatio < PlantData.WaterRatioMin) {
            return hydratationLevel.undeHydrated; 
        }else if (this.WaterRatio > PlantData.WaterRatioMax) {
            return hydratationLevel.overHydrated; 
        }else{
            return hydratationLevel.hydrated;
        }
    }

    public lightLevel LightLevel(){ //retourne -1 si sousexposé, 0 si c'est ok et 1 si surexposé 
        if(this.WaterRatio < PlantData.WaterRatioMin) {
            return lightLevel.underExposed; 
        }else if (this.WaterRatio > PlantData.WaterRatioMax) {
            return lightLevel.overExposed; 
        }else{
            return lightLevel.exposed;
        }
    }

    public bool Toxic(){
        if (this.ToxicRatio > PlantData.ToxicRatioMax){
            return true;
        }else{
            return false; 
        } 
    }

    public void SetDraggable(bool in_State)
    {
        _canBeDragged = in_State;
    }
}