using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilityCardManager : MonoBehaviour
{
    public int abilityNum;
    public int abilityType;

    TextMeshProUGUI textMeshProUGUI;

    GameObject abilityManager;
    public GameObject textPrefab;
    void Awake()
    {
        abilityManager = GameObject.Find("GameDirector");
        textMeshProUGUI = textPrefab.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateCard()
    {
        //textMeshProUGUI.text = "Num: " + abilityNum.ToString() + "\nType: " + abilityType.ToString();
        //textMeshProUGUI.text =
        switch (abilityType)
        {
            case 0:
                switch (abilityNum)
                {
                    case 0:
                        textMeshProUGUI.text = "Fast Feet";
                        break;
                    case 1:
                        textMeshProUGUI.text = "Fast Hand";
                        break;
                    case 2:
                        textMeshProUGUI.text = "Static Body";
                        break;
                    case 3:
                        textMeshProUGUI.text = "Horse's Foot";
                        break;
                    case 4:
                        textMeshProUGUI.text = "Unstable Body";
                        break;
                    case 5:
                        textMeshProUGUI.text = "Leap";
                        break;
                    case 6:
                        textMeshProUGUI.text = "Shotgun";
                        break;
                    default:
                        break;
                }
                break;
            case 1:
                switch (abilityNum)
                {
                    case 0:
                        textMeshProUGUI.text = "Assasin";
                        break;
                    case 1:
                        textMeshProUGUI.text = "Duplicate";
                        break;
                }
                        break;
            case 2:
                break;
            default:
                break;
        }
    }
    public void ChoiceCard()
    {
        abilityManager.GetComponent<AbilityManager>().GetAbility(abilityType, abilityNum);

        abilityManager.GetComponent<AbilityManager>().DestroyCard();
    }
}
