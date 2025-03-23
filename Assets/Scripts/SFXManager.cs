using System;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance {get; private set;}
    [SerializeField] private AudioSource plantSound;
    [SerializeField] private AudioSource rocket;
    [SerializeField] private AudioSource ding;
    [SerializeField] private AudioSource scanner;
    [SerializeField] private AudioSource succes;
    [SerializeField] private AudioSource motor;
    [SerializeField] private AudioSource water;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayPlantSound()
    {
        plantSound.Play();
    }
    
    public void PlayDingSound()
    {
        ding.Play();
    }
    public void PlayRocketSound()
    {
        rocket.Play();
    }
    public void PlayScannerSound()
    {
        scanner.Play();
    }

    public void StopScannerSound()
    {
        scanner.Stop();
    }
    
    public void PlaySuccesSound()
    {
        succes.Play();
    }
    public void PlayMotorSound()
    {
        motor.Play();
    }
    
    public void StopMotorSound()
    {
        motor.Stop();
    }
    
    
    public void PlayWaterSound()
    {
        water.Play();
    }

    public void StopWaterSound()
    {
        water.Stop();
    }
}
