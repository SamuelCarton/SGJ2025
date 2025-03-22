using System;
using TMPro;
using UnityEngine;
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
    }

    public void OnSelectCrop(Plant_Data data)
    {
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
        _plantParametter.Fertilizer =  1 - value;
    }
}