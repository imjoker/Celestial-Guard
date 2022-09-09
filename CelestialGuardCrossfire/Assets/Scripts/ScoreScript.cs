using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int scoreValue = 0;
    public TextMeshProUGUI score;

    void Start()
    {
        scoreValue = 0;
        score.text = "Score: " + scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue.ToString();
    }

    public void IncrementScore ()
    {
        ++scoreValue;
        Debug.Log("Score Increased " + scoreValue);
    }
}
