using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        StartCoroutine(SetFrame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SetFrame()
    {
        yield return new WaitForSeconds(2);
        Application.targetFrameRate = 144;
    }
}
