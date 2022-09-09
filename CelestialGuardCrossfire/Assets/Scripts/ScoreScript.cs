using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue = 0;
    Text score;


    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + scoreValue;
    }

     void Awake ()
    {
     score = GetComponent <Text> ();
     scoreValue = 0;
    }
}
