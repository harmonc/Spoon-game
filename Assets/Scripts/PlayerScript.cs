using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private float movementX;
    private float movementY;
    private Rigidbody2D rb;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementY, 0.0f);
        rb.velocity = movement*speed*Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.0f, 4.0f),Mathf.Clamp(transform.position.y, -2.0f, 2.0f),transform.position.z);

    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
