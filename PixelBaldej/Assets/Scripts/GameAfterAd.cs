using UnityEngine;

public class GameAfterAd : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("isItGameAfterAd", 1);
    }
}
