using UnityEngine;

public class Scanner : MonoBehaviour
{
    public void ScanPlant(Plant plant)
    {
        if(plant.GetQuality() >= 0.99){
            plant.isComestible = true; 
        }

        plant.isScanned = true;
        /*
        plant.ToxicRatio
        plant.WaterRatio
        plant.LightTime
        */

        UIManager.Instance.OpenScannerUI(plant); 

    }
}