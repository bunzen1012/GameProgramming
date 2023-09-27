using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Vector2 movementValue;
    private float lookValue;
    private Rigidbody rb;


    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * speed;
    }
    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }

    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X");
        //transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        //if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        //if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -speed * Time.deltaTime); }
        //if (Input.GetKey(KeyCode.A)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        //if (Input.GetKey(KeyCode.D)) { transform.Translate(speed * Time.deltaTime, 0, 0); }

        //transform.Translate(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime);

        //transform.Rotate(0, lookValue * Time.deltaTime, 0);

        rb.AddRelativeForce(movementValue.x * Time.deltaTime, 0, movementValue.y * Time.deltaTime, ForceMode.Impulse);
        //교수님이거 forcemode.impulse 없으면 안움직이던데 교재 자료에는 안나와있습니다!
        
        rb.AddRelativeTorque(0, lookValue * Time.deltaTime, 0);
    }
}
