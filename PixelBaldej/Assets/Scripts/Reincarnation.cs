using UnityEngine;

public class Reincarnation : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.instance.Play("Reincarnation");
    }
}
