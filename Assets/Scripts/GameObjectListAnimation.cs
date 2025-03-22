using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectListAnimation : MonoBehaviour
{
    [SerializeField] private List<GameObject> elements;
    [SerializeField] private float switchDelay;
    [SerializeField] private float switchRandomRange;

    private float nextSwitchTime = 0f;
    private int index = 0;
    
    void Update()
    {
        if (Time.time < nextSwitchTime)
        {
            return;
        }
        index = (index + 1) % elements.Count;
        ShowOneElement(index);
        nextSwitchTime =  Time.time + switchDelay + Random.Range(-switchRandomRange, switchRandomRange);
    }

    private void ShowOneElement(int index)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (i == index)
            {
                elements[i].SetActive(true);
                continue;
            }
            elements[i].SetActive(false);
        }
    }
}
