using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StalkerEnemyAi : MonoBehaviour
{
    GameObject player;

    Rigidbody rb;
    float moveSpeed = 0.0f;
    float jumpSpeed = 0.0f;

    bool onCollision = false;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        moveSpeed = GetComponent<EnemyStatus>().moveSpeed;
        jumpSpeed = GetComponent<EnemyStatus>().jumpSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, moveSpeed * -1000.0f));
            Debug.Log("A");
        }
    }
}
