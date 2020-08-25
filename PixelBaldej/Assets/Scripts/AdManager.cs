using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string placement = "rewardedVideo";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("3780979", true);
    }
        
    public void ShowAd()
    {
        if (Advertisement.IsReady(placement))
            Advertisement.Show(placement);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("isItGameAfterAd", 1);
            PlayerPrefs.SetInt("interimScore", GameMaster.instance.GetPlayerScore());
            SceneManager.LoadScene("GameAfterAd");
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }
}
