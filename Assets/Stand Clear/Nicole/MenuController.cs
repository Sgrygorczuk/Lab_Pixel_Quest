using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string startScene;
    public string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(startScene);
    }

    public void ReturnLevel() 
    {

        string thisLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(thisLevel);
    
    
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
