using System;
using System.Collections;
using UnityEngine;

public class StartingGame : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        UIManager.Instance.OpenPopup("" +
            "Mars fait l’objet de convoitises depuis plusieurs siècles, de nos jours l’Homme est sur le point de réaliser ce grand rêve. " +
            "Vous avez été choisis en tant qu'agriculteur martien pour préparer l’arrivée de plusieurs colons."
            );
    }
}