using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverTextController : MonoBehaviour
{
    float time = 0;
    int second = 0;
    int min = 0;

    int killCount = 0;

    TextMeshProUGUI textMeshProUGUI;

    public GameObject textPrefab;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = textPrefab.GetComponent<TextMeshProUGUI>();
        time = PlayerPrefs.GetFloat("Time");
        second = (int)time % 60;
        min = (int)time / 60;
        killCount = PlayerPrefs.GetInt("Kill");
        textMeshProUGUI.text = "Survive Time : " + (min < 10 ? "0" + min.ToString() : min.ToString()) + " : " + (second < 10 ? "0" + second.ToString() : second.ToString())
            + "\nKill Count : " + killCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
