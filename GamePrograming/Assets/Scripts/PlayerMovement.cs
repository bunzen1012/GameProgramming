using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed, 0);
        if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, speed); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -speed); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-speed, 0, 0); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(speed, 0, 0); }
    }
}
