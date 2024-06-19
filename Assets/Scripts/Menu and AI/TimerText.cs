using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TimerText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public float startTimer = 60f;
    float timer;

    void Start()
    {
        timer = startTimer;
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        textMeshProUGUI.text = (startTimer - (int)Time.timeSinceLevelLoad).ToString("F0") + "s";

        if (timer <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}