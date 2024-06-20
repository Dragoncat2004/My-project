using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject player;

    public GameObject abilityCard;
    public GameObject abilityScreen;
    GameObject[] abilityCards;

    public int numberOfStatusAbility;
    public int numberOfPassiveAbility;
    public int numberOfActiveAbility;
    int numberOfAllAbility;

    public int numberOfSlot;


    //Type, Num, Amount
    public class Ability
    {
        private int type;
        private int num;
        private int amount;

        public Ability(int type, int num, int amout)
        {
            this.type = type; this.num = num; this.amount = amout;
        }

        public void Set(int type, int num, int amount)
        {
            this.type = type; this.num = num; this.amount = amount;
        }

        public void SetType(int type) { this.type = type; }
        public void SetNum(int num) { this.num = num; }
        public void SetAmount(int amount) { this.amount = amount; }

        public new int GetType() { return type; }
        public int GetNum() { return num; }
        public int GetAmount() { return amount; }

        public void GetAbility()
        {
            amount += 1;
        }
    }

    public Ability[] abilities;

    void Awake()
    {
        numberOfAllAbility = numberOfStatusAbility + numberOfPassiveAbility + numberOfActiveAbility;
        abilityCards = new GameObject[numberOfSlot];

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        abilities = new Ability [numberOfAllAbility];
        for (int i = 0; i < numberOfAllAbility; i++)
        {
            if (i < numberOfStatusAbility)
            {
                abilities[i] = new Ability(0, i, 0);
            }
            else if (i < numberOfStatusAbility + numberOfPassiveAbility)
            {
                abilities[i] = new Ability(1, i - numberOfStatusAbility, 0);
            }
            else
            {
                abilities[i] = new Ability(2, i - numberOfStatusAbility - numberOfPassiveAbility, 0);
            }
        }
    }

    public void DrawCard()
    {
        int abilityType;
        int abilityNum;
        for (int i = 0; i < numberOfSlot; i++)
        {
            int randomAbility = Random.Range(0, numberOfAllAbility);
            abilityType = abilities[randomAbility].GetType();
            abilityNum = abilities[randomAbility].GetNum();

            abilityCards[i] = Instantiate(abilityCard);
            abilityCards[i].transform.SetParent(abilityScreen.transform, false);

            abilityCards[i].GetComponent<RectTransform>().position = new Vector3 (Screen.width / (numberOfSlot + 1) * (i+1), Screen.height / 2, 0);

            abilityCards[i].GetComponent<AbilityCardManager>().abilityType = abilityType;
            abilityCards[i].GetComponent<AbilityCardManager>().abilityNum = abilityNum;

            abilityCards[i].GetComponent<AbilityCardManager>().CreateCard();
        }
    }

    public void DestroyCard()
    {
        for (int i = 0; i < numberOfSlot; i++)
        {
            Destroy(abilityCards[i]);
        }
        player.GetComponent<PlayerStatus>().Resume();
    }

    public void GetAbility(int type, int num)
    {
        abilities[FindAbilityCode(type, num)].GetAbility();
        switch (type)
        {
            case 0:
                GetStatusAbility(num);
                break;
            case 1:
                GetPassiveAbility(num);
                break;
            case 2:
                GetActiveAbility(num);
                break;
        }
    }

    public int FindAbilityCode(int type, int num)
    {
        switch (type)
        {
            case 0:
                return num;
            case 1:
                return num + numberOfActiveAbility;
            case 2:
                return num + numberOfActiveAbility + numberOfPassiveAbility;
        }
        return 0;
    }

    public int FindAbilityAmount(int type, int num)
    {
        return abilities[FindAbilityCode(type, num)].GetAmount();
    }

    public void GetStatusAbility(int abilityNum)
    {
        switch (abilityNum)
        {
            case 0:
                player.GetComponent<PlayerStatus>().IncreaseMoveSpeed(0.2f);
                break;
            case 1:
                player.GetComponent<PlayerStatus>().IncreaseAttackSpeed(5.0f);
                break;
            case 2:
                player.GetComponent<PlayerStatus>().IncreaseDef(5.0f);
                break;
            case 3:
                player.GetComponent<PlayerStatus>().IncreaseJumpSpeed(3.0f);
                break;
            case 4:
                player.GetComponent<PlayerStatus>().IncreaseHpRegen(1.0f);
                break;
            case 5:
                player.GetComponent<PlayerStatus>().IncreaseJumpCount(1);
                break;
            case 6:
                player.GetComponent<PlayerStatus>().IncreaseFireAngle(5.0f);
                player.GetComponent<PlayerStatus>().IncreaseProjectileCount(1);
                break;
            case 7:
                break;
            case 8:
                break;
        }
    }
    public void GetPassiveAbility(int abilityNum)
    {
        switch (abilityNum)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }
    public void GetActiveAbility(int abilityNum)
    {

    }
}
