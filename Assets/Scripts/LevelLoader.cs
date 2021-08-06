using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // config params
    [SerializeField] int delayToLoadStart = 4;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayToLoadStart);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
