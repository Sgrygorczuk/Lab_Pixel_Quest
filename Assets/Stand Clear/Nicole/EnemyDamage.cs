using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage: MonoBehaviour
{
    private BarrierHealths BarrierHealth;
    public int damage=2;

    public float timer = 3;
    private float current = 0;
    bool hit = false; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Touch");
        if (other.gameObject.tag == "Barrier") 
        {
            hit = true;
            Debug.Log("Attack");
            if (other.gameObject.GetComponent<barriervisiblity>().IsVisible())
            {
                other.gameObject.GetComponent<BarrierHealths>().TakeDamage(damage);
            }
            else
            {
                Destroy(gameObject);
            }
        
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Barrier")
        {
            hit = true;
            current -= Time.deltaTime;
            if (current < 0)
            {
                collision.gameObject.GetComponent<BarrierHealths>().TakeDamage(damage);
                current = timer;
                if(collision.gameObject.GetComponent<BarrierHealths>().health <= 0)
                {
                    collision.gameObject.GetComponent<BarrierHealths>().CheckLife();
                    Destroy(transform);
                }
            }
        }
        
    }

}
