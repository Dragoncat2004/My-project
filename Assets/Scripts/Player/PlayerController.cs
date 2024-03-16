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

    //status
    private float moveSpeed = 0;
    private float jumpSpeed = 0;
    private float gravityScale = 0;

    //script
    private bool onCollision = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraObject = GameObject.Find("Main Camera");
        cameraRotation = cameraObject.GetComponent<CameraController>().orientation;
        UpdateStatus();
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
        }
    }

    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            playerAttack.SetActive(true);
        }
        else
        {
            playerAttack.SetActive(false);
        }
        
    }

    void UpdateStatus()
    {
        this.moveSpeed = GetComponent<PlayerStatus>().moveSpeed;
        this.jumpSpeed = GetComponent<PlayerStatus>().jumpSpeed;
        this.gravityScale = GetComponent<PlayerStatus>().gravityScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(0);
        }
        
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            onCollision = true;
            rb.AddForce(new Vector3(0.0f, 3.0f, 0.0f));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") onCollision = false;
    }
}
