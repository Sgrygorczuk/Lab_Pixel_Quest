
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoController : MonoBehaviour
{
    private SpriteRenderer s;
    private Rigidbody2D rb;
    public int speed = 3;
    public string NextLevel = "Level 2";


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "Death":
                {
                    string thisLevel= SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thisLevel);
                    break;
                }
            case "Finish 1":
                {
                    SceneManager.LoadScene(NextLevel);
                    break;
                }
        }
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        s = GetComponent<SpriteRenderer>();
       
       
    }

    // Update is called once per frame
    void Update()
    {

       
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            s.color = Color.cyan;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            s.color = Color.magenta;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            s.color = Color.red;
        }

        /* if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
         {

             s.color = new Color(Random.Range(0,255), Random.Range(0, 255), Random.Range(0, 255), 1f);
         } */

    }
}
