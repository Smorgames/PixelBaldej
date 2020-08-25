using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    public void PauseOn()
    {
        Time.timeScale = 0f;
        AudioManager.instance.Play("Click");
        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        AudioManager.instance.Play("Click");
        pausePanel.SetActive(false);
    }

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
}
