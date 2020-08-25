using UnityEngine;

public class Tester : MonoBehaviour
{
    public void ResetParam()
    {
        PlayerPrefs.SetInt("bestScore", 0);
        PlayerPrefs.SetInt("wasHintShown", 0);
    }
}
