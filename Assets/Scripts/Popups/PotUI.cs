using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PotUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tittle;
    [SerializeField] private TextMeshProUGUI _regolithValue;
    [SerializeField] private TextMeshProUGUI _fetilizerValue;
    [SerializeField] private Image _cropIcon;
    [SerializeField]  private Slider _waterSlider;
    [SerializeField] private Slider _lightSlider;
    [SerializeField] private Slider _fertilizerSlider;
    
    private PlantParameter _plantParametter = new PlantParameter();
    private Pot pot;
    private Plant_Data _plantData;
    private float _startCompostValue;

    private void Start()
    {
        _waterSlider.onValueChanged.AddListener(OnWaterSliderValueChanged);
        _fertilizerSlider.onValueChanged.AddListener(OnFertilizerSliderValueChanged);
        _lightSlider.onValueChanged.AddListener(OnLightSliderValueChanged);
    }

    void OnDestroy()
    {
        _waterSlider.onValueChanged.RemoveListener(OnWaterSliderValueChanged);
        _fertilizerSlider.onValueChanged.RemoveListener(OnFertilizerSliderValueChanged);
        _lightSlider.onValueChanged.RemoveListener(OnLightSliderValueChanged);
    }

    public void OpenUI(Pot in_pot)
    {
        pot = in_pot;
        _cropIcon.enabled = false;
        _startCompostValue = ResourceManager.Instance.compostAmount;
    }

    public void OnSelectCrop(Plant_Data data)
    {
        _plantData = data;
        _tittle.text = data.plantName;
        _cropIcon.sprite = data.plantSprites[0];
        _cropIcon.enabled = true;
    }

    public void OnValidateParameters()
    {
        pot.StartGrowing(_plantData, _plantParametter);
        gameObject.SetActive(false);
    }

    private void OnWaterSliderValueChanged(float value)
    {
        _plantParametter.Water = value;
    }

    private void OnLightSliderValueChanged(float value)
    {
        _plantParametter.Light = value;
    }

    private void OnFertilizerSliderValueChanged(float value)
    {
        ResourceManager.Instance.compostAmount = _startCompostValue;
        if (value * ResourceManager.Instance.TotalMaterialInPot > ResourceManager.Instance.compostAmount)
        {
            value = _startCompostValue / ResourceManager.Instance.TotalMaterialInPot;
            _fertilizerSlider.value = value;
        }
        _plantParametter.Fertilizer = value;
        _fetilizerValue.text = "Fertilizer: " + (value * 100).ToString("F2") + "%";
        _regolithValue.text = "Regolith: " + ((1 - value) * 100).ToString("F2") + "%";
        ResourceManager.Instance.AddCompost(-value * ResourceManager.Instance.TotalMaterialInPot);
    }
}