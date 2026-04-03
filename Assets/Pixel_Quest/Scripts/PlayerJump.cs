using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public float fallForce = -1;
    private Vector2 gravityvector;

    //capsule
    public float capsuleHeight = 0.25f;
    public float capsuleRadius = 0.08f;

    //Ground Check
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundcheck;

    private bool _watercheck;
    private string _waterTag = "Water";

  


    // Start is called before the first frame update
    void Start()
    {
        gravityvector = new Vector2(0f, Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _groundcheck = Physics2D.OverlapCapsule( feetCollider.position,new Vector2(capsuleHeight, capsuleRadius), CapsuleDirection2D.Horizontal, 0, groundMask);


        if (Input.GetKeyDown(KeyCode.Space) && (_groundcheck || _watercheck))
        {
            rb.velocity =  new Vector2(rb.velocity.x , jumpForce);
        }

        if (rb.velocity.y < 0 && !_watercheck)
        {
            rb.velocity += gravityvector * (fallForce * Time.deltaTime);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag)){ _watercheck = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(_waterTag)) { _watercheck = false; }
    }
}
