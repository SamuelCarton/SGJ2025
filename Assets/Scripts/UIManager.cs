﻿using UnityEngine;

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
        potUI.gameObject.SetActive(false);
    }

    public void OpenScannerUI(Plant plant){
        scannerUI.gameObject.SetActive(true);
        scannerUI.putVals(plant); 
    }
}