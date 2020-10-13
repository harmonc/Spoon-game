using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector2 xBounds;
    public Vector2 yBounds;
    public GameObject gameOver;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;


    private float movementX;
    private float movementY;
    private Rigidbody2D rb;

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
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xBounds.x, xBounds.y), Mathf.Clamp(transform.position.y, yBounds.x, yBounds.y), transform.position.z);
    }

    public void Deleted(float yPos) {
        for (int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.tag == "Cream" && child.transform.position.y > yPos)
            {
                child.AddComponent<Rigidbody2D>();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && transform.childCount == 1) {
            gameOver.SetActive(true);
            spawner1.SetActive(false);
            spawner2.SetActive(false);
            spawner3.SetActive(true);
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
