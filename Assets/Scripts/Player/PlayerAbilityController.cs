using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerAbilityController : MonoBehaviour
{
    public GameObject cameraObject;

    GameObject hook;
    public GameObject playerHook;
    int isHookExist = 0;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowHook();
    }

    void ThrowHook()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (isHookExist == 0)
            {
                isHookExist = 1;
                hook = Instantiate(playerHook);
                hook.transform.position = cameraObject.transform.position;
                hook.transform.rotation = cameraObject.transform.rotation;
                hook.transform.Translate(new Vector3(0.0f, 0.0f, 1.0f));
                hook.GetComponent<Rigidbody>().AddForce(cameraObject.transform.forward * 5000.0f);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (hook == null)
                return;
            isHookExist = 0;
            hook.GetComponent<HookController>().HookDestroy();
            hook = null;
        }
    }

    //hook
    public void ActiveHook(GameObject hook)
    {
        Vector3 hookDirection = (hook.transform.position - gameObject.transform.position) / 3;
        rb.AddForce(hookDirection);
    }
}
