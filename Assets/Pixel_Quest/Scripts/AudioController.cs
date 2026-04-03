using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource coinSFX;
    public AudioSource checkpointSFX;
    public AudioSource deathSFX;
    public AudioSource heartSFX;

    public void PlayAudio(string audioname)
    {
        switch (audioname.ToLower())
        {
            case "coin":
                {
                    coinSFX.Play(); 
                    break;
                }
            case "checkpoint":
                {
                    checkpointSFX.Play();
                    break;
                }
            case "death":
                {
                    deathSFX.Play();
                    break;
                }
            case "heart":
                {
                    heartSFX.Play();
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
