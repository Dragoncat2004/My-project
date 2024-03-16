using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonoBonoEnemyAi : MonoBehaviour
{
    float yPosiotionPlus = 0.03f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.0f, yPosiotionPlus, 0.0f));
    }
}
