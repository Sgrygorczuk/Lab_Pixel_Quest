using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerstats : MonoBehaviour
{

    public string NextLevel = "Level 2";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        { 
            case "Finish":
                {
                    SceneManager.LoadScene(NextLevel);
                    break;
                }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
