using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = 1f;
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene("Menu");
    }

    public void Ad()
    {
        AudioManager.instance.Play("Click");
        // there well be ad
    }
}
