using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    float attackPoint;
    float attackSpeed;
    float statusAttackSpeed;
    float attackCooltime;
    float fireAngle;
    int projectileCount;

    public GameObject playerRangeAttack;
    public GameObject cameraObject;
    public GameObject laserLinePrefab;
    public GameObject gameDirector;

    public int attackType = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeScale != 0.0f)
        {
            UpdateStatus();
            Attack();
        }
    }

    void UpdateStatus()
    {
        statusAttackSpeed = GetComponent<PlayerStatus>().attackSpeed;
        attackSpeed = 1.0f / statusAttackSpeed;
        attackPoint = GetComponent<PlayerStatus>().attackPoint;
        fireAngle = GetComponent<PlayerStatus>().fireAngle;
        projectileCount = GetComponent<PlayerStatus>().projectileCount;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            attackType = attackType + 1;
        }
            if (Input.GetMouseButton(0))
        {
            if (attackCooltime <= 0)
            {
                switch (attackType % 2)
                {
                    case 0:
                        for(int i = 0; i < projectileCount; i++)
                            FireBullet();
                        break;
                    case 1:
                        FireLaser();
                        break;
                    default:
                        break;
                }
            }
            attackCooltime -= Time.deltaTime;
        }
    }

    void FireBullet()
    {
        GameObject rangeAttack = Instantiate(playerRangeAttack);
        rangeAttack.transform.position = cameraObject.transform.position;
        rangeAttack.transform.rotation = cameraObject.transform.rotation * Quaternion.Euler(new Vector3(UnityEngine.Random.Range(-fireAngle, fireAngle), UnityEngine.Random.Range(-fireAngle, fireAngle), UnityEngine.Random.Range(-fireAngle, fireAngle)));
        
        rangeAttack.transform.Translate(new Vector3(0.0f, 0.0f, 1.0f));
        rangeAttack.GetComponent<BulletController>().attackPoint = attackPoint;
        rangeAttack.GetComponent<Rigidbody>().AddForce(rangeAttack.transform.forward * 3000.0f);
        attackCooltime = attackSpeed;
    }

    void FireLaser()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject laserLine = Instantiate(laserLinePrefab);
            laserLine.GetComponent<LaserController>().Play(gameObject.transform.position, hit.point);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<EnemyStatus>().OnDamaged(attackPoint / 10.0f);
            }
        }
        attackCooltime = attackSpeed / 10.0f;
    }
}
