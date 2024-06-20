using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public Sprite crosshiar1;
    public Sprite crosshiar2;
    public Sprite crosshiar3;
    public Sprite crosshiar4;

    Image image;

    public int crosshairNum = 1;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeCrosshairImage()
    {
        switch (crosshairNum % 4)
        {
            case 0:
                image.sprite = crosshiar1;
                break;
            case 1:
                image.sprite = crosshiar2;
                break;
            case 2:
                image.sprite = crosshiar3;
                break;
            case 3:
                image.sprite = crosshiar4;
                break;
            default:
                break;
        }
    }

    public void leftArrowClick()
    {
        if (crosshairNum > 0)
        {
            crosshairNum -= 1;
        }
        else
        {
            crosshairNum = 3;
        }
        ChangeCrosshairImage();
    }

    public void rightArrowClick()
    {
        crosshairNum += 1;
        ChangeCrosshairImage();
    }
}
