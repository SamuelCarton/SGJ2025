﻿using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    public Action<Plant_Data> OnPlantDiscovered;
    
    [SerializeField] private Image glassImage;

    private void Start()
    {
        OnPlantDiscovered += GoalManager.Instance.OnPlantDiscovered;
        glassImage.enabled = false;
    }

    public void ValidatePlant(IDraggable draggable)
    {
        Plant plant = draggable as Plant;
        
        if (plant == null)
            return;
        
        if (plant.GetQuality() < 0.5f)
        {
            UIManager.Instance.OpenPopup("Ce Legume n'est pas propre à la consommation");
            return;
        }

        if (!GoalManager.Instance.allPlants.Contains(plant.PlantData))
        {
            UIManager.Instance.OpenPopup("Vous avez déjà réussi à produire un légume de ce type.");
            return;
        }
        SFXManager.Instance.PlaySuccesSound();
        OnPlantDiscovered.Invoke(plant.PlantData);
        plant.SetDraggable(false);
        glassImage.enabled = true;
    }
}