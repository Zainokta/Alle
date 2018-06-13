using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadScreenController : MonoBehaviour {
    public GameObject loadScreenObj;
    public GameObject loadButton;
    public Slider loadSlider;
    AsyncOperation async;

    public void LoadScreen(string SceneName)
    {
        StartCoroutine(LoadingScreen(SceneName));
    }

    IEnumerator LoadingScreen(string sceneName)
    {
        loadScreenObj.SetActive(true);
        loadButton.SetActive(false);
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            loadSlider.value = async.progress;
            if (async.progress == 0.9f)
            {
                loadSlider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
