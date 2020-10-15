using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecreamScript : MonoBehaviour
{
    public Sprite chocolate;
    public Sprite strawberry;
    public Sprite vanilla;
    public Sprite coffee;
    private GameObject top;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer cream = this.GetComponent<SpriteRenderer>();
        int r = Mathf.FloorToInt(Random.Range(0, 4));
        if (r == 0)
        {
            cream.sprite = chocolate;
        }
        else if (r == 1)
        {
            cream.sprite = strawberry;
        }
        else if (r == 2)
        {
            cream.sprite = vanilla;
        }
        else if (r == 3)
        {
            cream.sprite = coffee;
        }
        float r2 = Random.Range(0.5f,2.0f);
        transform.localScale = new Vector3(r2,r2,r2);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -45) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy") {
            PlayerScript test = this.GetComponentInParent<PlayerScript>();
            if (test != null) {
                test.Deleted(this.transform.position.y);
            }
            top.transform.position = gameObject.transform.position + new Vector3(-0.4f*transform.localScale.x, -0.7f * transform.localScale.y, -1.0f);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().gainPoint();
            top = collision.transform.Find("Top").gameObject;
            if (top.gameObject.transform.position.y < transform.position.y)
            {
                gameObject.GetComponent<AudioSource>().Play();
                this.gameObject.transform.SetParent(collision.gameObject.transform);
                top.transform.position = this.gameObject.transform.position + new Vector3(0.4f* transform.localScale.x, 0.7f * transform.localScale.y, -1.0f);
                Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
                Destroy(rb);
            }
        }
    }   
}
