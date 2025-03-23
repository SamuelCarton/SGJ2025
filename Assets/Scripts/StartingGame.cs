using System;
using System.Collections;
using UnityEngine;

public class StartingGame : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        UIManager.Instance.OpenPopup("Mars fait l’objet de convoitises depuis plusieurs siècles, de nos jours l’Homme est sur le point de réaliser ce grand rêve. Vous avez été envoyé pour contribuer à cet énorme projet en tant que cultivateur sur le sol martien avant l’arrivée de plusieurs colons.");
    }
}