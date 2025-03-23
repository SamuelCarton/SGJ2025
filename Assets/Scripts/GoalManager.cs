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
            UIManager.Instance.OpenPopup("Félicitations!!! Après une longue période de test, vous avez enfin réussi à faire pousser différents plants comestibles grâce à votre réflexion. Vos résultats seront précieux pour aider les futures générations. Grâce à vous, elles pourront alors survivre et améliorer leurs conditions de vie.");
        }
    }
}