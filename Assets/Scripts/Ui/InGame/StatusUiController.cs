using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUiController : MonoBehaviour
{
    public TextMeshProUGUI textTMP;

    GameObject player;

    float hp;
    void Start()
    {
        player = GameObject.Find("Player");
        hp = player.GetComponent<PlayerStatus>().hp; 
    }

    // Update is called once per frame
    void Update()
    {
        hp = player.GetComponent<PlayerStatus>().hp;
        textTMP.text = "HP: " + hp.ToString();
    }
}
