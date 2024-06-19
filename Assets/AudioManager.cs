using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    
    private static AudioManager audioManager;
    public static AudioManager Instance
    {
        get
        {
            return audioManager;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad (this);
		
        if (audioManager == null) {
            audioManager = this;
        } 
        else {
            Destroy(gameObject);
        }
    }
}
