﻿using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class Pot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private VisualPotMachine visual;
    
    public Plant plant;

    public float water;
    
    public void StartGrowing(Plant_Data plantData, PlantParameter plantParametter)
    {
        SFXManager.Instance.PlayWaterSound();
        visual.StartLight(plantParametter.Light);
        GameObject plantInstance = Instantiate(plantPrefab, PotsManager.Instance.GetCanvas());
        plantInstance.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        plant = plantInstance.GetComponent<Plant>();
        plant.PlantData = plantData;
        plant.LightTime = plantParametter.Light;
        plant.WaterRatio = plantParametter.Water;
        //recalculer la toxicité 
        plant.ToxicRatio = 1 - plantParametter.Fertilizer;
        plant.Weight = plantData.fertilizerAmount * plantData.PlantValidConditionRatio(plantParametter);
        
        IEnumerator coroutine = GrowCycle();
        StartCoroutine(coroutine);
    }

    private IEnumerator GrowCycle()
    {
        yield return new WaitForFixedUpdate();
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
        plant.SetDraggable(true);
        plant = null;
        yield return new WaitForSeconds(stepTime);
        visual.StopLight();
        SFXManager.Instance.StopWaterSound();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (plant != null)
        {
            return;
        }
        UIManager.Instance.OpenPotUI(this);
    }

    public void Click()
    {
        UIManager.Instance.OpenPotUI(this);
    }
}