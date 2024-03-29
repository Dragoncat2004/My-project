using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletLifeTimeLimit = 3.0f;
    float bulletLifeTime = 0.0f;
    public float attackDemage;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletLifeTime += Time.deltaTime;
        rb.AddRelativeForce(0.0f, 0.0f, 10.0f);
        if (bulletLifeTime >= bulletLifeTimeLimit)
        {
            Destroy(gameObject);
        }
    }
}
