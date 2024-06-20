using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    GameObject player;

    //using Hook
    public GameObject hookLinePrefab;
    GameObject hookLine;
    bool isActive = false;

    //lifeTime
    public float lifeTimeLimit = 3.0f;
    float lifeTime = 0.0f;

    Rigidbody rb;
    void Awake()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        hookLine = Instantiate(hookLinePrefab);
    }

    void Update()
    {
        hookLine.GetComponent<HookLineController>().Play(player.transform.position, gameObject.transform.position);
        rb.AddRelativeForce(0.0f, 0.0f, 10.0f);
        if (isActive)
        {
            hookLine.GetComponent<HookLineController>().Active();
            player.GetComponent<PlayerAbilityController>().ActiveHook(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        rb.isKinematic = true;
        isActive = true;
    }

    public void HookDestroy()
    {
        hookLine.GetComponent<HookLineController>().Stop();
        Destroy(hookLine);
        Destroy(gameObject);
    }

    void LifeTimeControl()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime >= lifeTimeLimit)
        {
            HookDestroy();
        }
    }
}
