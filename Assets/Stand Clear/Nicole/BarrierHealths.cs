using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierHealths : MonoBehaviour
{
    public int health;
    public int maxHealth=10;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void CheckLife()
    {
        if (health <= 0)
        {

            GetComponent<barriervisiblity>().SetVisibility(false);
            health = 10;


        }
    }
}
