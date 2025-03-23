using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VisualPotMachine : MonoBehaviour
{
    [SerializeField] Image image;
    private IEnumerator coroutine;

    private IEnumerator FlickerLight(float lightValue)
    {
        while (image.color.a < lightValue)
        {
            yield return new WaitForSeconds(0.03f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.01f);
        }
        yield return new WaitForSeconds(0.25f);
        while (image.color.a > 0)
        {
            yield return new WaitForSeconds(0.03f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.01f);
        }
        yield return new WaitForSeconds(0.25f);
        yield return FlickerLight(lightValue);
    }

    public void StopLight()
    {
        image.color = new Color(1, 1, 1, 0);
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    public void StartLight(float lightValue)
    {
        coroutine = FlickerLight(lightValue);
        StartCoroutine(coroutine);
    }
}