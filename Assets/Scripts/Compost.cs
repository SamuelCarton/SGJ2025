using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compost : MonoBehaviour
{
    private List<Plant> plantes; 
    
    //composter la plante au bout d'un certain moment en appelant la coroutine
    public void compostStart(IDraggable draggable){
        if (!draggable.IsAPlant()){
            return;
        }
        StartCoroutine(compost((Plant)draggable)); 
    }


    private IEnumerator compost(Plant plant){
        plant.gameObject.SetActive(false);
        yield return new WaitForSeconds(plant.PlantData.decompositionTime); 
        //Calcul de la valeur de compost à retourner
        float valComp = (plant.Poids * 10) * plant.GetQuality(); 
        ResourceManager.Instance.compostAmount += valComp;
        Destroy(plant.gameObject); 
    }

}
