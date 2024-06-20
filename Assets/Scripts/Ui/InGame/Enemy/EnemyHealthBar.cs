using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public GameObject enemy;
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = 1 - enemy.GetComponent<EnemyStatus>().hp / enemy.GetComponent<EnemyStatus>().maxHp;
    }
}
