using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreenToolkit : MonoBehaviour
{
    public UIDocument document;
    public Button startButton;
    public Button settingButton;
    public Button customizeButton;
    void Start()
    {
        startButton = document.rootVisualElement.Q<Button>("Start");
        startButton.clicked += startGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startGame()
    {
        Debug.Log("1");
    }
}
