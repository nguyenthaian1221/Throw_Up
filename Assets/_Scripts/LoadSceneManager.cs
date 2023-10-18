using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.SearchService;

public class LoadSceneManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;


    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
       
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        LoadingScreen.SetActive(true);


        while (!operation.isDone)
        {
 
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingBarFill.fillAmount = progressValue;
            yield return null;
        }

    }



    public void LoadGamePlayScene()
    {
        //SceneManager.LoadScene(1);
        LoadScene(1);
    }

    public void BackToMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }



}
