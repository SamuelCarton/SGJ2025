using UnityEngine;

public class Scanner : MonoBehaviour
{
    public void ScanPlant(IDraggable draggable)
    {
        if (draggable is not Plant)
        {
            return;
        }
        Plant plant = (Plant) draggable;
        
        if(plant.GetQuality() >= 0.99){
            plant.isComestible = true; 
        }

        plant.isScanned = true;

        UIManager.Instance.OpenScannerUI(plant); 

    }
    
    
}