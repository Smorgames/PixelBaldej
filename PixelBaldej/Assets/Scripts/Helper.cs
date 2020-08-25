using UnityEngine;

public class Helper : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject helpText;
    [SerializeField] private GameObject helpText2;
    [SerializeField] private GameObject helper;
    [SerializeField] private GameObject background;

    [SerializeField] private GameObject[] holes;

    private void Start()
    {
        if (PlayerPrefs.GetInt("wasHintShown", 0) == 0)
        {
            Time.timeScale = 0f;
            AdjustHoleColliders(false);
        }
        else
        {
            Time.timeScale = 1f;
            background.SetActive(false);
            AdjustHoleColliders(true);
        }
    }

    public void SkipFirstHint()
    {
        helpText.SetActive(false);
        button2.SetActive(true);
        helpText2.SetActive(true);
        button.SetActive(false);
    }

    public void SkipFirstHint2()
    {
        PlayerPrefs.SetInt("wasHintShown", 1);
        Time.timeScale = 1f;
        AdjustHoleColliders(true);
        helper.SetActive(false);
    }

    private void AdjustHoleColliders(bool enabled)
    {
        for (int i = 0; i < holes.Length; i++)
            holes[i].GetComponent<Collider2D>().enabled = enabled;
    }
}
