using UnityEngine;

public class SaveDifficultyLevel : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerPrefs.SetInt("interimDifficultyLevel", GameObject.FindWithTag("Spawner").GetComponent<Spawner>().GetDifficultyLevel());
    }
}
