using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        AudioManager.instance.Play("Click");
        Application.Quit();
    }
}
