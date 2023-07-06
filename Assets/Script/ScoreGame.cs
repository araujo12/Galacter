using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGame : MonoBehaviour
{
    public int point = 1, addPoint;
    public Text scoreText;
    public static bool destroyed;
    
    void Start()
    {
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        AtScore();
    }

    public void AtScore()
    {
        if(destroyed == true)
        {
            addPoint = point++;
            scoreText.text = addPoint.ToString();
            destroyed = false;
        }

    }   

    
}
