using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite fork;
    public Sprite knife;
    void Start()
    {
        SpriteRenderer utensil = this.GetComponent<SpriteRenderer>();
        int r = Mathf.FloorToInt(Random.Range(0, 2));
        if (r == 0)
        {
            utensil.sprite = fork;
        }
        else if (r == 1)
        {
            utensil.sprite = knife;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
