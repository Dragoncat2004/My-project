using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialController : MonoBehaviour
{
    float r;
    float g;
    float b;
    public Material playerMaterial;
    void Start()
    {
        r = PlayerPrefs.GetFloat("Red");
        g = PlayerPrefs.GetFloat("Green");
        b = PlayerPrefs.GetFloat("Blue");
        playerMaterial.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        playerMaterial.color = new Color(r, g, b);
        playerMaterial.SetColor("_EmissionColor", new Color(r, g, b));
    }
}
