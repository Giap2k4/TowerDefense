using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : GapiMonoBehaviour
{
    [SerializeField] private Slider loadingSlider;

    protected override void Start()
    {
        StartCoroutine(LoadMainSceneAsync());
    }

    private IEnumerator LoadMainSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingSlider.value = progress;

            if (asyncLoad.progress >= 0.9f)
            {
                loadingSlider.value = 1f;
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
