using UnityEngine;

public class Scanner : MonoBehaviour
{
    public void ScanPlant(Plant plant)
    {
        if(plant.GetQuality() >= 0.99){
            plant.isComestible(true); 
        }
    }
    
    
}