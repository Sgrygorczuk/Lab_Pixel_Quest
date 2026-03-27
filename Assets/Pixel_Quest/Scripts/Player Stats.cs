using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int CoinCounter = 0;
    public int coinsInLevel = 0;
    public int Health = 3;
    public int maxHealth = 3;
    public Transform respawnPoint;
    private PlayerUIController _playerUIController;
    private AudioController _audioController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "Death":
                {
                    Health--;
                    _audioController.PlayAudio("death");
                    _playerUIController.UpdateHealth(Health, maxHealth);
                    string thisLevel = SceneManager.GetActiveScene().name;
                    if (Health <= 0)
                    {
                        SceneManager.LoadScene(thisLevel);
                        Health = 3;
                    }
                    else
                    {
                        transform.position = respawnPoint.position;
                    }
                    break;
                }
            case "Finish":
                {
                    string nextLevel = collision.transform.GetComponent<LevelGoal>().nextLevel;
                    SceneManager.LoadScene(nextLevel);
                    break;
                }
            case "Coin":
                {
                    CoinCounter++ ;
                    _audioController.PlayAudio("coin");
                    _playerUIController.UpdateCoin(CoinCounter + "/" + coinsInLevel);
                    Destroy(collision.gameObject); 
                    break;
                }
            case "Health":
                {
                    if (Health < 3)
                    {
                       Health++;
                        _audioController.PlayAudio("heart");
                        _playerUIController.UpdateHealth(Health, maxHealth);
                        Destroy(collision.gameObject);
                    }
                    break;
                }
            case "Respawn":
                {
                    
                    respawnPoint.position = collision.transform.Find("Point").position;
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
        _playerUIController = GetComponent<PlayerUIController>();
        _playerUIController.UpdateHealth(Health, maxHealth);
        coinsInLevel = GameObject.Find("Coin").transform.childCount;
        _playerUIController.UpdateCoin(CoinCounter + "/" + coinsInLevel);
        _audioController = GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
