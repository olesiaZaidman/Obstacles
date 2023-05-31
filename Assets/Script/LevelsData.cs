using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsData : MonoBehaviour
{    
    static LevelsData instance;
    static float difficulty = 1f;
    static int score;
    static int hits;
    public static int Score { get { return score; } }
    public static int Hits { get { return hits; } }
    public static float Difficulty { get { return difficulty; } }


    public static TimeSpan overallTime; //Timer.finishTime
   // public static float gameDurationInSeconds = 0;

  public static List<TimeSpan> finishScores = new List<TimeSpan>();

   // static TimeSpan bestTimeScore;
  //  int currentSceneIndex;
    public const int maxScores = 5;

    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {

        if (instance != null)
        {
            gameObject.SetActive(false);
            // we disable it on Awake before we destroy it, so no component will try to access it
            Destroy(gameObject);
        }

        else
        // we need to transit this AudioPlayer through all the rest of the scenes on Load
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            //the existing AudiPlayer will be passed to another scene
        }

    }
   
    void Start()
    {
        RestartScore();
    }

    public static void RestartScore()
    {
        //gameDurationInSeconds = 0;
        difficulty = 1f;
        overallTime = TimeSpan.Zero;
        score = 0;
        hits = 0;
      //  Debug.Log("Restarted");    
    }

    public static float IncreaseGameDifficulty(float _mod)
    {
        difficulty *= _mod;
       // Debug.Log("difficulty: "+ difficulty);
        return difficulty;
    }


    public static void SaveData() //we call it in SaveScoreOverallTime that is called in Timer 
    {
        finishScores.Add(overallTime);
        finishScores.Sort(TimeSpan.Compare);  // finishScores.Sort();


        // remove everything after index 5 :
        if (finishScores.Count > maxScores)
        {
            finishScores.RemoveRange(maxScores, finishScores.Count - maxScores);
        }
    }

  


    public static void AddScore(int points)
    {
        score += points;
        GamePlayTimer.PenaltyTimeEvent();
        hits++;        //hits += 1;
                       // print(score);
                       //print("You bumped: "+ hits +" times");
    }

    public static void SaveScoreOverallTime(TimeSpan _levelTimeToFinish)
    {
        overallTime += _levelTimeToFinish;
       // gameDurationInSeconds = (float)overallTime.TotalSeconds;

    //    Debug.Log("Your overallTime: " + overallTime.ToString(@"mm\:ss"));
    }
}
