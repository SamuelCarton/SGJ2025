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

        yield return new WaitForSeconds(plant.PlantData.decompositionTime); 
        ResourceManager.Instance.compostAmount += plant.Poids;
        Destroy(plant); 
    }

}
