using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttackController : MonoBehaviour
{
    public float lifeTimeLimit = 3.0f;
    float lifeTime = 0.0f;
    public float attackPoint;
    Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0.0f)
        {
            Move();
        }
    }

    void Move()
    {
        lifeTime += Time.deltaTime;
        rb.AddRelativeForce(0.0f, 0.0f, 50.0f);
        if (lifeTime >= lifeTimeLimit)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
