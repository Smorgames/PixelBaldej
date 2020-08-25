using UnityEngine;
using System.Collections;

public class PixelBaldej : MonoBehaviour
{
    public GameObject decore;

    private Transform[] decoreObjects; 

    private void Awake()
    {
        decoreObjects = new Transform[decore.transform.childCount];

        for (int i = 0; i < decore.transform.childCount; i++)
            decoreObjects[i] = decore.transform.GetChild(i);
    }

    public void PixelBaldejClick()
    {
        AudioManager.instance.Play("Click");

        StartCoroutine(PixelBaldejCoroutine());

        foreach (Transform decoreObject in decoreObjects)
            decoreObject.GetComponent<DecoreObject>().Burst();
    }

    private IEnumerator PixelBaldejCoroutine()
    {
        for (int i = 0; i < decoreObjects.Length / 2; i++)
        {
            AudioManager.instance.Play("PixelBaldej");
            yield return new WaitForSeconds(0.03f);
        }
    }
}
