using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public float hpRegen;
    public float def;

    public float attackPoint;
    public float attackSpeed;
    public float critPer;
    public float critPoint;

    public float moveSpeed;
    public float jumpSpeed;
    public int jumpCount;
    public float gravityScale;

    public float evasion;

    public float xp;
    public float maxXp;
    public float level;

    public float fireAngle;
    public int projectileCount;

    public GameObject levelUpScreen;
    public GameObject GameDirector;
    public GameObject timer;

    int mobKillCount = 0;

    void Awake()
    {
        hp = maxHp;
    }

    void Update()
    {
        checkLevelUp();
        RegenHp();
    }

    void checkLevelUp()
    {
        if (xp >= maxXp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        maxHp *= 1.2f;
        hp = maxHp;

        xp = xp - maxXp;
        maxXp *= 1.2f;

        attackPoint *= 1.2f;

        level += 1;

        GameDirector.GetComponent<AbilityManager>().DrawCard();

        Time.timeScale = 0.0f;
        levelUpScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
    }

    public void Resume()
    {
        gameObject.GetComponent<PlayerController>().UpdateStatus();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        levelUpScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    //getter
    public float GetXp() { return xp; }

    //setter
    public void SetXp(float value) { xp = value; }
    public void SetFireAngle(float value) { fireAngle = value; }

    //manipulater
    public void IncreaseXp(float value) { xp += value; }
    public void IncreaseMoveSpeed(float value) { moveSpeed += value; }
    public void IncreaseAttackSpeed(float value) { attackSpeed += value; }
    public void IncreaseDef(float value) { def += value; }
    public void IncreaseJumpSpeed(float value) { jumpSpeed += value; }
    public void IncreaseKillCount(int value) { mobKillCount += value; }
    public void IncreaseJumpCount(int value) { jumpCount += value; }
    public void IncreaseHpRegen(float value) { hpRegen += value; }
    public void IncreaseFireAngle(float value) { fireAngle += value; }
    public void IncreaseProjectileCount(int value) { projectileCount += value;  }


    //collsion and hp control
    private void OnCollisionEnter(Collision collision)
    {
        getDamaged(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        getDamaged(other.gameObject);
    }

    void getDamaged(GameObject other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyAttack")
        {
            gameObject.GetComponent<PlayerController>().GetKnockback(other.gameObject);
            hp -= other.gameObject.GetComponent<EnemyStatus>().attackDamage;
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        PlayerPrefs.SetFloat("Time",timer.GetComponent<TimeController>().getTime());
        PlayerPrefs.SetInt("Kill", mobKillCount);
        SceneManager.LoadScene(2);
    }

    void RegenHp()
    {
        if ((hp + hpRegen * Time.deltaTime) >= maxHp)
        {
            hp = maxHp;
            return;
        }
        else hp += hpRegen * Time.deltaTime;
    }
}
