using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUiController : MonoBehaviour
{
    public GameObject settingScreen;
    public GameObject startScreen;
    public GameObject loadingScreen;
    public GameObject customizeScreen;
    public GameObject crosshairObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OpenSetting()
    {
        settingScreen.SetActive(true);
        startScreen.SetActive(false);
    }

    public void ExitSetting()
    {
        settingScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void OpenCustomize()
    {
        customizeScreen.SetActive(true);
        startScreen.SetActive(false);
    }

    public void ExitCustomize()
    {
        customizeScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void StartLoadScene()
    {
        SaveChanges();
        StartCoroutine(LoadGameSceneAsync());
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

    void SaveChanges()
    {
        PlayerPrefs.SetFloat("Red", gameObject.GetComponent<CustomizeController>().saveColor().r);
        PlayerPrefs.SetFloat("Green", gameObject.GetComponent<CustomizeController>().saveColor().g);
        PlayerPrefs.SetFloat("Blue", gameObject.GetComponent<CustomizeController>().saveColor().b);
        PlayerPrefs.SetInt("Crosshair", crosshairObject.GetComponent<CrosshairController>().crosshairNum);
    }
}
