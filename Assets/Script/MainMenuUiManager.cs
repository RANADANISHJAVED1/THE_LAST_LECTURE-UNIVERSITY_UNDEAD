using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUiManager : MonoBehaviour
{
    public GameObject LoadingPanal;
    public Image loadingImage;
    public Text loadingPercentage;
    public Text loadingDots;
    AsyncOperation loadNewScene;
    public void ExitBtnClicked()
    {
        Application.Quit();
    }
    public void LoadGameScene(int missionNumber)
    {
        LoadingPanal.SetActive(true);
        StartCoroutine(MissionBtnClicked(missionNumber));
     //   StartCoroutine(LoadingDotsIncrement());
    }
    private IEnumerator LoadingDotsIncrement()
    {
        loadingDots.text = "LOADING";
        yield return new WaitForSeconds(0.5f);
        loadingDots.text = "LOADING.";
        yield return new WaitForSeconds(0.5f);
        loadingDots.text = "LOADING..";
        yield return new WaitForSeconds(0.5f);
        loadingDots.text = "LOADING...";
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(LoadingDotsIncrement());
    }
    private IEnumerator MissionBtnClicked(int missionNumber)
    {
        yield return null;
        if (missionNumber == 1)
        {
            loadNewScene = SceneManager.LoadSceneAsync(missionNumber);
        }
        else if (missionNumber == 2)
        {
             loadNewScene = SceneManager.LoadSceneAsync(missionNumber);
        }
        else if (missionNumber == 3)
        {
            loadNewScene = SceneManager.LoadSceneAsync(missionNumber);
        }
       // loadNewScene.allowSceneActivation = false;
        while (!loadNewScene.isDone)
        {
            if (loadNewScene.progress < 0.99f)
            {
                loadingImage.fillAmount = loadNewScene.progress;
                loadingPercentage.text = ((int)(loadNewScene.progress * 100)).ToString("00")+"%";
            }
            else
            {
                loadingImage.fillAmount = 1;
                loadingPercentage.text = "100";
               // loadNewScene.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}
