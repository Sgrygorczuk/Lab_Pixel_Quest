using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;
    public GameObject EndGame;
    public int barrierCount = 0;
    public int WinAmount = 2;
    public Transform Barriers;
    public string  nxlvl;
    public string lose;

    void Update()
    {
        if (remainingTime > 0) 
        {
        
            remainingTime-= Time.deltaTime;
            if (remainingTime < 0)
            {
                remainingTime = 0;
            }
        
        }
        else if (remainingTime < 0) 
        {
            int countGood = 0;
            for (int i = 0; i < Barriers.childCount; i++)
            {
                if (Barriers.GetChild(i).GetComponent<SpriteRenderer>().enabled)
                {
                    countGood++;
                }
            }

            remainingTime = 0;
            Time.timeScale = 0f;

            if (countGood < WinAmount)
            {
                //EndGame.SetActive(true);
                SceneManager.LoadScene(nxlvl);
            }
            else
            {
                SceneManager.LoadScene(lose);
            }

        }

       
        
        
        
        
        
        
        

        
            remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}