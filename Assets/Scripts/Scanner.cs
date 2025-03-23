using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scanner : MonoBehaviour
{
    [SerializeField] private GameObject image;
    public void ScanPlant(IDraggable draggable)
    {
        if (draggable is not Plant)
        {
            return;
        }
        SFXManager.Instance.PlayScannerSound();
        Plant plant = (Plant) draggable;
        
        IEnumerator coroutine = MoveScan();
        StartCoroutine(coroutine);
        
        if(plant.GetQuality() >= 0.99){
            plant.isComestible = true; 
        }

        plant.isScanned = true;

        UIManager.Instance.OpenScannerUI(plant);
    }

    IEnumerator MoveScan()
    {
        Debug.Log("Scanning..." + image.GetComponent<RectTransform>().anchoredPosition.y);
        while (image.GetComponent<RectTransform>().anchoredPosition.y < 33)
        {
            yield return new WaitForEndOfFrame();
            Vector3 pos = image.GetComponent<RectTransform>().anchoredPosition;
            pos.y += 1f;
            image.GetComponent<RectTransform>().anchoredPosition = pos;
        }
        while (image.GetComponent<RectTransform>().anchoredPosition.y > -85)
        {
            yield return new WaitForEndOfFrame();
            Vector3 pos = image.GetComponent<RectTransform>().anchoredPosition;
            pos.y -= 1f;
            image.GetComponent<RectTransform>().anchoredPosition = pos;
        }
        while (image.GetComponent<RectTransform>().anchoredPosition.y < 0)
        {
            yield return new WaitForEndOfFrame();
            Vector3 pos = image.GetComponent<RectTransform>().anchoredPosition;
            pos.y += 1f;
            image.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }
}