using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScannerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI plantName; 
    [SerializeField] private TextMeshProUGUI valWater; 
    [SerializeField] private TextMeshProUGUI valLight;
    [SerializeField] private TextMeshProUGUI valTox;  


    
    public void putVals(Plant plant){
        plantName.text = plant.name;
        if(plant.Toxic()){
            valTox.text = "Teneur en excès"; 
        }

        
    }   


}