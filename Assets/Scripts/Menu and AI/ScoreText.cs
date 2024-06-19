using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    
    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "Score: " + ScoreManager.Instance.score.ToString();
    }
}
