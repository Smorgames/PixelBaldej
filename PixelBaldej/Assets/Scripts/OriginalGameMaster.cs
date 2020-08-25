using UnityEngine;

public class OriginalGameMaster : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("isItGameAfterAd", 0);
    }
}
