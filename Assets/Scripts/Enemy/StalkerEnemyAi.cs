using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StalkerEnemyAi : MonoBehaviour
{
    GameObject player;

    Rigidbody rb;
    float moveSpeed;
    float jumpSpeed;
    float dashCooltime;
    float dashCooltimeTimer = 0.0f;
    float attackDemage;

    float maxHp;
    float hp;

    bool onCollision = false;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        moveSpeed = GetComponent<EnemyStatus>().moveSpeed;
        jumpSpeed = GetComponent<EnemyStatus>().jumpSpeed;
        maxHp = GetComponent<EnemyStatus>().maxHp;
        hp = maxHp;
        dashCooltime = GetComponent<EnemyStatus>().dashCooltime;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Dash();
    }

    void Movement()
    {
        transform.LookAt(player.transform.position);
        rb.AddRelativeForce(new Vector3(0.0f, 0.0f, moveSpeed));
        if (Input.GetKeyDown(KeyCode.Space) && onCollision)
        {
            rb.AddForce(new Vector3(0, jumpSpeed, 0));
        }
    }

    void Dash()
    {
        dashCooltimeTimer += Time.deltaTime;
        if (dashCooltimeTimer > dashCooltime)
        {
            rb.AddRelativeForce(Vector3.forward * 100.0f);
            dashCooltimeTimer = 0.0f;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") onCollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") onCollision = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            OnDemaged(other.gameObject.GetComponent<BulletController>().attackDemage);
        }
    }

    void OnDemaged(float demage)
    {
        hp -= demage;
        if (hp < 0.0f)
        {
            Destroy(gameObject);
        }
        rb.AddRelativeForce(new Vector3(0.0f, 0.0f, moveSpeed * -50.0f));
    }
}
