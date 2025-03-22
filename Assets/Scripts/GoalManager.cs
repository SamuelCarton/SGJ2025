using System;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public static GoalManager Instance;
    public static Action FinishGame;

    void Awake()
    {
        Instance = this;
    }
    
    public List<Plant_Data> allPlants;

    public void OnPlantDiscovered(Plant_Data data)
    {
        if (!allPlants.Contains(data))
        {
            return;
        }
        allPlants.Remove(data);
        if (allPlants.Count == 0)
        {
            FinishGame?.Invoke();
        }
    }
}