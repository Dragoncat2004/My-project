using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorController : MonoBehaviour
{
    public GameObject stalker;

    float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            Instantiate(stalker);
            timer = 0.0f;
        }
    }
}
