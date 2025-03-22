using System.Collections;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;
    public Plant plant;
    

    public float water;
    
    public void StartGrowing(Plant_Data plantData)
    {
        GameObject plantInstance = Instantiate(plantPrefab,  transform.position, Quaternion.identity);
        plant = plantInstance.GetComponent<Plant>();
        
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
}