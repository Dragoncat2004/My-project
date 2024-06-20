using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    TextMeshProUGUI textMeshProUGUI;

    public GameObject textPrefab;

    float time = 0.0f;
    int second = 0;
    int min = 0;

    void Awake()
    {
        textMeshProUGUI = textPrefab.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        second = (int)time % 60;
        min = (int)time / 60;
        textMeshProUGUI.text = (min < 10 ? "0" + min.ToString() : min.ToString()) + " : " + (second < 10 ? "0" + second.ToString() : second.ToString());
    }

    public float getTime() {  return time; }
}
