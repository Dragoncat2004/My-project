using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartButtonTextController : MonoBehaviour
{
    float timer = 0;

    TextMeshPro textMeshPro;
    public TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        //TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Rolling()
    {
        timer += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, ((timer * (1 + timer / 10)) % 360) * 400);
        textMeshProUGUI.color = new Color(timer % 2 <= 1 ? timer % 2 : 2 - timer % 2,
            timer * 1.3f % 2 <= 1 ? timer * 1.3f % 2 : 2 - timer * 1.3f % 2,
            timer * 1.5f % 2 <= 1 ? timer * 1.5f % 2 : 2 - timer * 1.5f % 2);
    }
}
