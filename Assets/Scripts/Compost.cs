using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compost : MonoBehaviour
{
    private List<Plant> plantes;
    [SerializeField] private Slider _compostAmountBar;

    private void Start()
    {
        ResourceManager.Instance.OnCompostAmountChanged += SetBarValue;
        ResourceManager.Instance.AddCompost(0);
    }

    private void SetBarValue(float value)
    {
        _compostAmountBar.value = value;
    }

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
        float valComp = plant.Weight; 
        ResourceManager.Instance.AddCompost(valComp);
        Destroy(plant.gameObject); 
    }

}
