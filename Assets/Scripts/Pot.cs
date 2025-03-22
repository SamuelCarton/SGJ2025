using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class Pot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject plantPrefab;
    public Plant plant;
    

    public float water;
    
    public void StartGrowing(Plant_Data plantData, PlantParametter plantParametter)
    {
        GameObject plantInstance = Instantiate(plantPrefab,  transform.position, Quaternion.identity);
        plant = plantInstance.GetComponent<Plant>();
        plant.PlantData = plantData;
        plant.LightTime = plantParametter.Light;
        plant.WaterRatio = plantParametter.Water;
        plant.ToxicRatio = 1 - plantParametter.Fertilizer;
        
        IEnumerator coroutine = GrowCycle();
        StartCoroutine(coroutine);
    }

    private IEnumerator GrowCycle()
    {
        float stepTime = plant.PlantData.GrowingTime / 4.0f;
        if (plant.PlantData.plantSprites.Count < 4)
        {
            Debug.Log("No Sprite Set in plant: " + plant.PlantData.plantName + plant.PlantData.plantSprites.Count);
            yield break;
        }
        plant.SetSprite(plant.PlantData.plantSprites[0]);
        yield return new WaitForSeconds(stepTime);
        plant.SetSprite(plant.PlantData.plantSprites[1]);
        yield return new WaitForSeconds(stepTime);
        plant.SetSprite(plant.PlantData.plantSprites[2]);
        yield return new WaitForSeconds(stepTime);
        plant.SetSprite(plant.PlantData.plantSprites[3]);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (plant != null)
        {
            return;
        }

        UIManager.Instance.OpenPotUI(this);
    }
}