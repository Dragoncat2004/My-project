using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCircleController : MonoBehaviour
{
    GameObject player;
    float hp = 0;
    float maxHp = 0;
    Image img;
    void Start()
    {
        player = GameObject.Find("Player");

        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = player.GetComponent<PlayerStatus>().hp;
        maxHp = player.GetComponent<PlayerStatus>().maxHp;
        img.fillAmount = hp / maxHp;
    }
}
