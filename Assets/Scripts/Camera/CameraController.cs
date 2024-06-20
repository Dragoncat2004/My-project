using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    public float sensitivityX;
    public float sensitivityY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public bool isThirdPerson = false;
    void Start()
    {
        player = GameObject.Find("Player");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isThirdPerson = isThirdPerson ? false : true;
        }

        if (isThirdPerson)
        {
            getRotation();
        }
        else
        {
            getRotation();
            transform.position = player.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        }
        
        //rotate camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        orientation.rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
    }


    void getRotation()
    {
        //마우스의 xy값 받아오기
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
    }
}
