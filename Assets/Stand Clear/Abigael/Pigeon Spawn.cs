using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonSpawn : MonoBehaviour
{
    public GameObject pigeon;
    public Transform pigeonSpawn;
    private float _currentTime = 0.5F;
    public float Rest = 2;
    private bool _canShoot = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        _currentTime -= Time.deltaTime;

         if (_currentTime < 0)
          {
              Instantiate(pigeon, pigeonSpawn.position, Quaternion.identity);
              _currentTime = Rest;
          }
    }
}
