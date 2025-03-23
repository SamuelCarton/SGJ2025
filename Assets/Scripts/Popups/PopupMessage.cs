using System.Collections;
using TMPro;
using UnityEngine;

public class PopupMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _messageText;
    private IEnumerator coroutine;
    public void SetMessage(string message)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = _showMessageCoroutine(message);
        StartCoroutine(coroutine);
    }

    private IEnumerator _showMessageCoroutine(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            _messageText.text = message.Substring(0, i+1);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
}