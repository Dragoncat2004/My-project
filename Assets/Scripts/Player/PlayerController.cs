using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    public GameObject cameraObject;
    Transform cameraRotation;

    public GameObject gameDirector;
    
    //get Component
    ParticleSystem particle;
    Rigidbody rb;

    //status
    private float moveSpeed;
    private float jumpSpeed;
    private float gravityScale;
    public float airTime;

    //ability
    private int jumpCountMax = 1;
    public int jumpCount = 0;

    //script
    private bool onCollision = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraRotation = cameraObject.GetComponent<CameraController>().orientation;
        particle = GetComponent<ParticleSystem>();
        UpdateStatus();
        
    }

    void Update()
    {
        if (Time.timeScale != 0.0f)
        {
            Movement();
            GravityScale();
        }
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
        if(Input.GetKeyDown(KeyCode.Space) && (jumpCount < jumpCountMax))
        {
            rb.velocity = new Vector3 (rb.velocity.x, 10 * jumpSpeed, rb.velocity.z);
            rb.AddRelativeForce(Vector3.forward * moveSpeed);
            //rb.AddForce(new Vector3(0, jumpSpeed, 0));
            jumpCount++;
            onCollision = false;
        }
    }

    void GravityScale()
    {
        if(rb.velocity.y >= 0.0f || onCollision)
        {
            airTime = 0.0f;
        }
        else
        {
            airTime += airTime >= 5.0f ?  0.0f : Time.deltaTime; 
            rb.AddForce(new Vector3 (0, -airTime * gravityScale, 0));
        }
    }
    public void UpdateStatus()
    {
        this.moveSpeed = GetComponent<PlayerStatus>().moveSpeed;
        this.jumpSpeed = GetComponent<PlayerStatus>().jumpSpeed;
        this.gravityScale = GetComponent<PlayerStatus>().gravityScale;
        this.jumpCountMax = GetComponent<PlayerStatus>().jumpCount;
    }

    public void GetKnockback(GameObject target)
    {
        rb.AddForce(target.transform.forward * 100.0f);
        particle.Play();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            onCollision = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") onCollision = false;
    }
}
