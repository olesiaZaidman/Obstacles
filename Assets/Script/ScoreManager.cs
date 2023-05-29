using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static int score;
    static int hits;
    public static int Score { get { return score; } }
    public static int Hits { get { return hits; } }

    static bool isFinishLevel = false;
    public static TimeSpan overallTime; //Timer.finishTime


    public static bool IsFinishLevel { get { return isFinishLevel; } }

    public static void FinishLevel()
    {
        isFinishLevel = true;
    }
    void Start()
    {
        RestartScore();
    }

    void RestartScore()
    {
        isFinishLevel = false;
        score = 0;
        hits = 0;
    }

    public static void AddScore(int points)
    {
        score += points;
        GamePlayTimer.PenaltyTimeEvent();
        hits++;        //hits += 1;
       // print(score);
        //print("You bumped: "+ hits +" times");
    }

    public static void ScoreOverallTime(TimeSpan _levelTimeToFinish)
    {
        overallTime += _levelTimeToFinish;
        Debug.Log("Your overallTime: " + overallTime.ToString(@"mm\:ss"));
    }
}
