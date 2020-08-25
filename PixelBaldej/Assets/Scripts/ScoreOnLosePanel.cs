using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreOnLosePanel : MonoBehaviour
{
    private TextMeshProUGUI textScore;

    private void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(ScoreCount());
    }

    private IEnumerator ScoreCount()
    {
        yield return new WaitForSecondsRealtime(0.9f);

        int count = 0;

        while(count <= GameMaster.instance.GetPlayerScore())
        {
            textScore.text = count.ToString();
            yield return new WaitForSecondsRealtime(0.01f);
            count++;
        }
    }
}
