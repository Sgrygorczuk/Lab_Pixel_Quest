using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public float waitTime = 1;
    private float currentTime = 1;
    public float speed = 5;
    public Transform[] patrolPoints;
    public int patrolIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[patrolIndex].position;
        currentTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolIndex].position, speed * Time.deltaTime);

        if (transform.position == patrolPoints[patrolIndex].position)
        {
            patrolIndex++;
            if(patrolIndex >= patrolPoints.Length)
            {
                patrolIndex = 0;
            }

        else
            {
                currentTime -= Time.deltaTime;
            }

        }
    }
}
