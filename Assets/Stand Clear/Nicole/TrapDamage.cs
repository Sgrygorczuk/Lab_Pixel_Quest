using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    private EnemyHealth EnemyHealth;
    public int damage = 2;

    public float timer = 3;
    private float current = 0;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Touch");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Attack");
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        current -= Time.deltaTime;
        if (current < 0)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            current = timer;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
