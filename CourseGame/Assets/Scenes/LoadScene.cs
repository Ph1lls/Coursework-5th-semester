using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LoadScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider scale;
    public int newScene;

    public void LoadingScen()
    {
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(newScene);
        loadAsync.allowSceneActivation = false;

        while(!loadAsync.isDone)
        {
            scale.value = loadAsync.progress;

            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(3f);
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
