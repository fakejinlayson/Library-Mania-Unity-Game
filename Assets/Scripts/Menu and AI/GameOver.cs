using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [SerializeField] SfxManager sfx;
    [SerializeField] AudioClip clip;

    void Start()
    {
        SfxManager sfxObj = Instantiate(sfx.gameObject, transform.position, Quaternion.identity).GetComponent<SfxManager>();
        sfxObj.PlaySound(clip);

        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
            PlayerPrefs.Save();
        }

        int highScorePrefs = PlayerPrefs.GetInt("highscore");

        if (ScoreManager.Instance.score > highScorePrefs)
        {
            PlayerPrefs.SetInt("highscore", ScoreManager.Instance.highScore);
            PlayerPrefs.Save();
            highScorePrefs = ScoreManager.Instance.score;
        }

        ScoreManager.Instance.highScore = highScorePrefs;

        scoreText.text = "Score: " + ScoreManager.Instance.score.ToString();
        highScoreText.text = "High Score: " + ScoreManager.Instance.highScore.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScoreManager.Instance.score = 0;

            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScoreManager.Instance.score = 0;

            SceneManager.LoadScene("Home");
        }
    }
}
