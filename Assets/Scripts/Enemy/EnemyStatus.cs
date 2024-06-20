using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class EnemyStatus : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float maxHp;
    public float hp;
    public float attackDamage;
    public float attackSpeed;

    public int isDestroy = 0;

    public GameObject player;
    public GameObject gameDirector;

    GameObject script;

    void Awake()
    {
        player = GameObject.Find("Player");
        gameDirector = GameObject.Find("GameDirector");

        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isDestroy == 0)
        {
            if (other.gameObject.tag == "PlayerAttack")
            {
                int ability_1_1 = gameDirector.GetComponent<AbilityManager>().FindAbilityAmount(1, 1);
                int multiAttackNum = 2;
                if (ability_1_1 == 0)
                    OnDamaged(other.gameObject.GetComponent<BulletController>().attackPoint);
                else
                {
                    for (int i = 0; i < multiAttackNum; i++)
                    {
                        OnDamaged((other.gameObject.GetComponent<BulletController>().attackPoint)* (0.5f + 0.1f * (ability_1_1 - 1)));
                    }
                }
            }
        }
    }

    public void OnDamaged(float damage)
    {
        if (gameObject.GetComponent<StalkerEnemyAi2D>() != null)
        {
            gameObject.GetComponent<StalkerEnemyAi2D>().GetKnockback();
        }
        else if (gameObject.GetComponent<WizardEnemyController>() != null)
        {
            gameObject.GetComponent<WizardEnemyController>().GetKnockback();
        }
        
        damage = DamageCalculationByAbility(damage);
        hp -= damage;
        if (hp <= 0.0f)
        {
            Die();
            return;
        }
    }

    float DamageCalculationByAbility(float damage)
    {
        int ability_1_0 = gameDirector.GetComponent<AbilityManager>().FindAbilityAmount(1, 0);
        if (ability_1_0 != 0 && hp >= maxHp * 0.9f)
            return damage * (1 + ability_1_0 * 0.5f);
        else
            return damage;
    }

    void Die()
    {
        gameObject.tag = "Dead";
        isDestroy = 1;
        player.GetComponent<PlayerStatus>().IncreaseXp(1.0f);
        player.GetComponent<PlayerStatus>().IncreaseKillCount(1);

        if (gameObject.GetComponent<StalkerEnemyAi2D>() != null)
        {
            gameObject.GetComponent<StalkerEnemyAi2D>().Die();
        }
        else if (gameObject.GetComponent<WizardEnemyController>() != null)
        {
            gameObject.GetComponent<WizardEnemyController>().Die();
        }
    }
    
}
