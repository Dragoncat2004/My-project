using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartLoadScene()
    {
        StartCoroutine(LoadGameSceneAsync());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private IEnumerator LoadGameSceneAsync()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Stage_0");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        loadingScreen.SetActive(false);
    }
}
