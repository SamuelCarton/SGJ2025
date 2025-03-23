using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuStart : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject QuitButton;

    public void ButtonStart()
    {
        SceneManager.LoadScene("SampleScene");
        print("Commençons le game");
    }

    public void Quit()
    {
        Application.Quit();
        print("Au revoir");
    }
}
