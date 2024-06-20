using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StalkerEnemyAi2D : MonoBehaviour
{
    GameObject player;

    Rigidbody rb;
    ParticleSystem particle;
    public Material transparent;

    float moveSpeed;
    float jumpSpeed;
    float dashCooltime;
    float dashCooltimeTimer = 0.0f;
    float attackDamage;

    public int isDestroy = 0;

    bool onCollision = false;
    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        particle = GetComponent<ParticleSystem>();

        moveSpeed = GetComponent<EnemyStatus>().moveSpeed;
        jumpSpeed = GetComponent<EnemyStatus>().jumpSpeed;
        dashCooltime = GetComponent<EnemyStatus>().attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0.0f)
        {
            if (isDestroy == 0)
            {
                Movement();
                Dash();
            }
            else
                ParticleDestroyCheck();
        }
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
        if (dashCooltimeTimer > 1.0f / dashCooltime)
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

    public void GetKnockback()
    {
        rb.AddRelativeForce(new Vector3(0.0f, 0.0f, moveSpeed * -50.0f));
        particle.Play();
    }
    void ParticleDestroyCheck()
    {
        if (isDestroy == 1 && particle.IsAlive() == false)
        {
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        isDestroy = 1;
        rb.isKinematic = true;
        gameObject.GetComponent<SpriteRenderer>().material = transparent;
    }




}
