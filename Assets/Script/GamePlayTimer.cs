using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    float extraPenaltyTime = 5;

    DateTime startTime;
    TimeSpan elapsedTime;
    TimeSpan penaltyTime;

    public static TimeSpan finishTime; //Timer.finishTime
    

    private bool timerRunning = false;
    private static bool isPenalty = false;

    void Start()
    {
        timerRunning = false;
        StartTimer();
    }

    void StartTimer()
    {
        if (!timerRunning)
        {
            startTime = DateTime.Now;
            timerRunning = true;
           // Debug.Log("Timer started" + elapsedTime.ToString(@"hh\:mm\:ss\.fff"));
        }
    }

    void UpdateTimer()
    {
        elapsedTime = DateTime.Now - startTime;
    }


    void Update()
    {

        if (timerRunning)
        {
            UpdateTimer();

            if (isPenalty)
            {
                AddPenaltyTime();
                isPenalty = false; // Reset the event flag
            }

            timeText.SetText(GetDisplayTime().ToString(@"mm\:ss"));
            //   Debug.Log("Current time: " + GetDisplayTime().ToString(@"hh\:mm\:ss\.fff"));
        }

        if (timerRunning && ScoreManager.IsFinishLevel)
        {
            StopTimer();
            SaveTimeScore();
        }
    }

    void  AddPenaltyTime()
    {
        penaltyTime = penaltyTime.Add(TimeSpan.FromSeconds(extraPenaltyTime));

        //  timeText.SetText(elapsedTime.ToString(@"mm\:ss"));
    }
    public static void PenaltyTimeEvent() //Add to Collisions
    {
        isPenalty = true;
    }


    void StopTimer()
    {
        elapsedTime = DateTime.Now - startTime;
        timerRunning = false;
      //  Debug.Log("Timer stopped. Elapsed time: " + elapsedTime.ToString(@"hh\:mm\:ss\.fff"));
    }


    TimeSpan SaveTimeScore()
    {
        finishTime = GetDisplayTime();
        ScoreManager.ScoreOverallTime(finishTime);
        //  Debug.Log("Your Score: " + finishTime.ToString(@"mm\:ss"));
        return finishTime;
    }

    TimeSpan GetDisplayTime()
    {
        return elapsedTime + penaltyTime;
    }
}
