using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    GameObject cameraObject;
    Transform cameraRotation;
    public GameObject playerAttack;
    public GameObject playerRangeAttack;

    //status
    private float moveSpeed = 0;
    private float jumpSpeed = 0;
    private float gravityScale = 0;
    float attackDemage;
    float attackSpeed;
    float attackCooltime;
    float maxHp;
    public float hp;


    //script
    private bool onCollision = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraObject = GameObject.Find("Main Camera");
        cameraRotation = cameraObject.GetComponent<CameraController>().orientation;
        UpdateStatus();
        hp = maxHp;
    }

    void Update()
    {
        Movement();   
        Attack();
    }

    void Movement()
    {
        transform.rotation = cameraRotation.rotation;
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(new Vector3(-moveSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(new Vector3(moveSpeed, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(0, 0, moveSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(0, 0, -moveSpeed));
        }
        if(Input.GetKeyDown(KeyCode.Space) && onCollision)
        {
            rb.AddForce(new Vector3(0, jumpSpeed, 0));
            onCollision = false;
        }
    }

    void Attack()
    {
        if (Input.GetMouseButton(1))
        {
            playerAttack.SetActive(true);
        }
        else
        {
            playerAttack.SetActive(false);
        }
        if (Input.GetMouseButton(0))
        {
            if(attackCooltime <= 0)
            {
                GameObject rangeAttack = Instantiate(playerRangeAttack);
                rangeAttack.transform.position = cameraObject.transform.position;
                rangeAttack.transform.rotation = cameraObject.transform.rotation;
                rangeAttack.transform.Translate(new Vector3(0.0f, 0.0f, 1.0f));
                rangeAttack.GetComponent<BulletController>().attackDemage = attackDemage;
                rangeAttack.GetComponent<Rigidbody>().AddForce(cameraObject.transform.forward * 1000.0f);
                attackCooltime = attackSpeed;
            }
            attackCooltime -= Time.deltaTime;
        }
    }

    void UpdateStatus()
    {
        this.moveSpeed = GetComponent<PlayerStatus>().moveSpeed;
        this.jumpSpeed = GetComponent<PlayerStatus>().jumpSpeed;
        this.gravityScale = GetComponent<PlayerStatus>().gravityScale;
        attackSpeed = GetComponent<PlayerStatus>().attackSpeed;
        attackDemage = GetComponent<PlayerStatus>().attackDemage;
        maxHp = GetComponent<PlayerStatus>().maxHp;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            rb.AddForce(collision.gameObject.transform.forward * 100.0f);
            hp -= collision.gameObject.GetComponent<EnemyStatus>().attackDemage;
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            onCollision = true;
            //rb.AddForce(new Vector3(0.0f, 3.0f, 0.0f));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") onCollision = false;
    }
}
