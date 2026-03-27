using UnityEngine;

public class HW2PlayerShoot : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public Transform bulletTrash;
    public Transform bulletSpawn;

    private const float Timer = 0.5f;
    private float _currentTime = 0.5F;
    private bool _canShoot = true;

    private void Update()
    {
        TimerMethod();
        Shoot1();
        Shoot2();
    
        
        
       
    }

    private void TimerMethod()
    {
        if (!_canShoot)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime < 0)
            {
                _canShoot = true;
                _currentTime = Timer;
            }
        }

    }

    private void Shoot1()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
        {
            GameObject bullet1 = Instantiate(prefab1, bulletSpawn.position, Quaternion.identity);

            bullet1.transform.SetParent(bulletTrash);

            _canShoot = false;
        }
    }

    private void Shoot2()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _canShoot)
        {
            GameObject bullet2 = Instantiate(prefab2, bulletSpawn.position, Quaternion.identity);

            bullet2.transform.SetParent(bulletTrash);

            _canShoot = false;
        }
    }
}
