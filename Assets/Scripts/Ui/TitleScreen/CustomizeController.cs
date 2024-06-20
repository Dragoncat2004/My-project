using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeController : MonoBehaviour
{
    public GameObject redObject;
    public GameObject greenObject;
    public GameObject blueObject;
    public GameObject player;

    Slider redSlider;
    Slider greenSlider;
    Slider blueSlider;

    public Material playerMaterial;
    void Start()
    {
        redSlider = redObject.GetComponent<Slider>();
        greenSlider = greenObject.GetComponent<Slider>();
        blueSlider = blueObject.GetComponent<Slider>();
        playerMaterial.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        playerMaterial.color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        playerMaterial.SetColor("_EmissionColor", new Color(redSlider.value, greenSlider.value, blueSlider.value));
    }

    public Color saveColor()
    {
        return playerMaterial.color;
    }
}
