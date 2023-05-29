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
        score = 0;
        hits = 0;
    }

    public static void AddScore(int points)
    {
        score += points;
        hits++;        //hits += 1;
        print(score);
        print("You bumped: "+ hits +" times");
    }
}
