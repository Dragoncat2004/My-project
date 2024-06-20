using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEnemyController : MonoBehaviour
{
    GameObject player;

    Rigidbody rb;
    ParticleSystem particle;
    public Material transparent;

    public GameObject attackPrefab;

    float moveSpeed;
    float jumpSpeed;
    float attackCooltime;
    public float attackCooltimeTimer = 0.0f;
    float attackDamage;
    float attackSpeed;

    public int isDestroy = 0;

    bool onCollision = false;
    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        particle = GetComponent<ParticleSystem>();

        moveSpeed = GetComponent<EnemyStatus>().moveSpeed;
        jumpSpeed = GetComponent<EnemyStatus>().jumpSpeed;
        attackCooltime = GetComponent<EnemyStatus>().attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0.0f)
        {
            if (isDestroy == 0)
            {
                Movement();
                Attack();
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

    void Attack()
    {
        attackCooltimeTimer += Time.deltaTime;
        if (attackCooltimeTimer > 1.0f / attackCooltime)
        {
            GameObject attack = Instantiate(attackPrefab);
            attack.transform.position = gameObject.transform.position + new Vector3(0.0f,1.0f,0.0f);
            attack.transform.LookAt(player.transform.position);
            attackCooltimeTimer = 0.0f;
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
