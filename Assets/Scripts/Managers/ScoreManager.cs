using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int bookScore = 5;
    public int aiScore = 10;

    public int highScore = 0;

    private static ScoreManager scoreManager;
    public static ScoreManager Instance
    {
        get
        {
            // if (scoreManager == null)
            // {
            //     scoreManager = FindObjectOfType<ScoreManager>();
            //     if (scoreManager == null)
            //     {
            //         GameObject obj = new GameObject("ScoreManager");
            //         DontDestroyOnLoad(obj);
            //         scoreManager = obj.AddComponent<ScoreManager>();
            //     }
            // }
            return scoreManager;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad (this);
		
        if (scoreManager == null) {
            scoreManager = this;
        } 
        else {
            Destroy(gameObject);
        }
    }


    public void AddScore(int amount)
    {
        score += amount;
    }

    public void RemoveScore(int amount)
    {
        score -= amount;
    }
}

