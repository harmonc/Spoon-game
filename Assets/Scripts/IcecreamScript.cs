using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecreamScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Test");
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.transform.SetParent(collision.gameObject.transform);
            Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
            Destroy(rb);
            this.tag = "Player";
        }
    }
}
