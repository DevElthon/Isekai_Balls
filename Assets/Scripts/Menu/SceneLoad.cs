using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public static string scene;
    public static int phase;
    [SerializeField] Image loadingBArFill;

    void Start()
    {
        LoadScene();
    }
    public void LoadScene()
    {
        Debug.Log(scene);
        StartCoroutine(LoadSceneAsync(scene));
    }

    IEnumerator LoadSceneAsync(string sceneId)
    {
        yield return new WaitForSeconds(0.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBArFill.fillAmount = progressValue;
            if (Mathf.Approximately(operation.progress, 0.9f))
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}