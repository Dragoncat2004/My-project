using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    GameObject cameraObject;
    Transform cameraRotation;

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
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpSpeed, 0));
        }

        //rb.velocity = new Vector3(rb.velocity.x * 0.97f, rb.velocity.y, rb.velocity.z * 0.97f);
    }

    void UpdateStatus()
    {
        this.moveSpeed = GetComponent<PlayerStatus>().moveSpeed;
        this.jumpSpeed = GetComponent<PlayerStatus>().jumpSpeed;
        this.gravityScale = GetComponent<PlayerStatus>().gravityScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        onCollision = true;
    }
}

/*
 if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += new Vector3(-moveSpeed, 0.0f, 0.0f);
            if (rb.velocity.x < -moveSpeed)
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, rb.velocity.z);
            }
        }else if (rb.velocity.x < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x * drag, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += new Vector3(moveSpeed, 0.0f, 0.0f);
            if (rb.velocity.x > moveSpeed)
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z);
            }
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x * drag, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += new Vector3(0.0f, 0.0f, moveSpeed);
            if (rb.velocity.z > moveSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
            }
        }
        else if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z * drag);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector3(0.0f, 0.0f, -moveSpeed);
            if (rb.velocity.z < -moveSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -moveSpeed);
            }
        }
        else if (rb.velocity.z < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z * drag);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += new Vector3(0.0f,jumpSpeed,0.0f);
            Debug.Log(rb.velocity.y);
        }
        onCollision = false;
 */