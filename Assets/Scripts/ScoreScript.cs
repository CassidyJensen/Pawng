using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    // public int leftScore, rightScore;

    public static ScoreScript S;
    //capital S  & static - access from anywhere

       void Awake()
    {
        S = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scorer)
    {
        // player 0 is left, player 1 is right
        if (scorer == 0) DisplayScript.leftScore++;
        if (scorer == 1) DisplayScript.rightScore++;
    }

    public void ResetScore()
    {
       DisplayScript.leftScore = 0;
        DisplayScript.rightScore = 0;
    }
}
