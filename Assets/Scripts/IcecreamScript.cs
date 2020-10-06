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
        if (collision.gameObject.tag == "Player")
        {
            GameObject top = collision.transform.Find("Top").gameObject;
            if (top.gameObject.transform.position.y < transform.position.y)
            {
                this.gameObject.transform.SetParent(collision.gameObject.transform);
                top.transform.position = this.gameObject.transform.position + new Vector3(0.0f,1.0f,-1.0f);
                Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
                Destroy(rb);
                Debug.Log("test2");
            }
        }
    }   
}
