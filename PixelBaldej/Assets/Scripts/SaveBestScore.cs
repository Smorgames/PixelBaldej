using UnityEngine;

public class SaveBestScore : MonoBehaviour
{
    public void SaveBestScoreFunc()
    {
        if (GameMaster.instance.GetPlayerScore() > PlayerPrefs.GetInt("bestScore"))
            PlayerPrefs.SetInt("bestScore", GameMaster.instance.GetPlayerScore());
    }
}
