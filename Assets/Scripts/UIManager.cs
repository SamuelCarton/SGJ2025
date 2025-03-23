using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private PotUI potUI;
    [SerializeField] private ScannerUI scannerUI;
    [SerializeField] private PopupMessage popupMessage;
    
    void Awake()
    {
        Instance = this;
    }

    public void OpenPotUI(Pot pot)
    {
        potUI.OpenUI(pot);
        potUI.gameObject.SetActive(true);
    }

    public void OpenScannerUI(Plant plant){
        Debug.Log(plant.name);
        scannerUI.putVals(plant); 
        scannerUI.gameObject.SetActive(true);
        
    }

    public void OpenPopup(string message)
    {
        popupMessage.gameObject.SetActive(true);
        popupMessage.SetMessage(message);
    }
}