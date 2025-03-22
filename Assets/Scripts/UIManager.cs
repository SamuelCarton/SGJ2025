using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private PotUI potUI;
    [SerializeField] private ScannerUI scannerUI;
    
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
        scannerUI.putVals(plant); 
        scannerUI.gameObject.SetActive(true);
        
    }
}