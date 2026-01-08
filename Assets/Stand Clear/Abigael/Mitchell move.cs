using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mitchellmove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer f;
    public int speed = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        f = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        if (xInput > 0)
        {
            f.flipX = false;
        }
        else if (xInput < 0)
        {
            f.flipX = true;
        }

        float yInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x , yInput * speed);
        //if (xInput > 0)
        //{
           // f.flipX = true;
       // }
       // else if (xInput < 0)
       // {
         //   f.flipX = false;
     //   }
    }
}
