using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScannerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI plantName; 
    [SerializeField] private TextMeshProUGUI valWater; 
    [SerializeField] private TextMeshProUGUI valLight;
    [SerializeField] private TextMeshProUGUI valTox;  
    [SerializeField] private TextMeshProUGUI engrais; 


    
    public void putVals(Plant plant){
        //On désactive le texte d'engrais à chaque fois 
        engrais.gameObject.SetActive(false);

        plantName.text = plant.name;
        if(plant.Toxic()){
            valTox.text = "Teneur en excès"; 
        }else{
            valTox.text = "Permissible"; 
        }

        switch(plant.LightLevel()){
            case lightLevel.underExposed:   
                valLight.text = "Sous-exposition";
            break;

            case lightLevel.overExposed:
                valLight.text = "Sur-exposition";
            break; 
            case lightLevel.exposed:
                valLight.text = "Bonne exposition à la lumière";
            break; 
        }

        switch(plant.HydratationLevel()){
            case hydratationLevel.undeHydrated:   
                valWater.text = "Déshydratation";
            break;

            case hydratationLevel.overHydrated:
                valWater.text = "Sur-hydratation";
            break; 
            case hydratationLevel.hydrated:
                valWater.text = "Bon niveau d'eau";
            break; 
        }

        if(plant.ToxicRatio < 0.5f){
            Debug.Log("Toxix paradise"); 
            engrais.gameObject.SetActive(true);  
        }


    
    }   


}