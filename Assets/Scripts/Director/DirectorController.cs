using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorController : MonoBehaviour
{
    public GameObject stalker;

    float timer = 0.0f;

    public float maxGeneration;

    void Start()
    {
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Obstacle");
            if (enemy.Length < maxGeneration )
            {
                Instantiate(stalker);
            }
            
            timer = 0.0f;
        }
    }
}
