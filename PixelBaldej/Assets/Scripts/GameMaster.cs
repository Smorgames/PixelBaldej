using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    public GameObject losePanel;

    public TextMeshProUGUI scoreText;
    private Animator scoreTextAnimator;

    private int playerScore;

    public GameObject[] objectsNeedToDisable;

    public GameObject holeReplica;

    private void Start()
    {
        playerScore = 0;
        scoreTextAnimator = scoreText.GetComponent<Animator>();

        if (PlayerPrefs.GetInt("isItGameAfterAd") == 1)
            playerScore = PlayerPrefs.GetInt("interimScore");
    }

    public void ChangeScore(int amount)
    {
        playerScore += amount;
        scoreText.text = playerScore.ToString();
        scoreTextAnimator.SetTrigger("PlusPoint");
    }

    public void Lose()
    {
        DisableGameObjects(objectsNeedToDisable);
        losePanel.SetActive(true);
    }

    private void DisableGameObjects(GameObject[] arrayNeedToDisable)
    {
        for (int i = 0; i < arrayNeedToDisable.Length; i++)
            Destroy(arrayNeedToDisable[i]);

        for (int i = 0; i < 3; i++)
            Instantiate(holeReplica, arrayNeedToDisable[i].transform.position, Quaternion.identity);

    }

    public int GetPlayerScore()
    {
        return playerScore;
    }
}
