using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawningObject;

    public float timer;

    public Transform[] spawnPoints;

    private float timeToNextSpawn;
    private int difficultyLevel = 0;

    private void Start()
    {
        timeToNextSpawn = 4.3f;

        if (PlayerPrefs.GetInt("isItGameAfterAd") == 1)
        {
            difficultyLevel = PlayerPrefs.GetInt("interimDifficultyLevel");
            SetTimeToNextSpawn();
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToNextSpawn)
        {
            timer = 0;
            DifficultyAlgorithm();
        }
    }

    private void DifficultyAlgorithm()
    {
        if (difficultyLevel != 9)
            Instantiate(spawningObject, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);

        switch (difficultyLevel)
        {
            case 9:
                for (int i = 0; i < spawnPoints.Length; i++)
                    Instantiate(spawningObject, spawnPoints[i].position, Quaternion.identity);
                AudioManager.instance.Play("WaveUp");
                break;
            case 10:
                ChangeDifficulty(4.2f);
                break;
            case 15:
                ChangeDifficulty(4.0f);
                break;
            case 20:
                ChangeDifficulty(3.1f);
                break;
            case 45:
                ChangeDifficulty(2.8f);
                break;
            case 50:
                ChangeDifficulty(2.6f);
                break;
            case 70:
                ChangeDifficulty(2.5f);
                break;
        }

        difficultyLevel++;
    }

    public int GetDifficultyLevel()
    {
        return difficultyLevel;
    }

    private void ChangeDifficulty(float time)
    {
        timeToNextSpawn = time;
        AudioManager.instance.Play("WaveUp");
    }

    private void SetTimeToNextSpawn()
    {
        if (difficultyLevel >= 9)
            timeToNextSpawn = 4.2f;
        if (difficultyLevel >= 15)
            timeToNextSpawn = 4.0f;
        if (difficultyLevel >= 20)
            timeToNextSpawn = 3.1f;
        if (difficultyLevel >= 45)
            timeToNextSpawn = 2.8f;
        if (difficultyLevel >= 50)
            timeToNextSpawn = 2.6f;
        if (difficultyLevel >= 70)
            timeToNextSpawn = 2.5f;
    }
}
