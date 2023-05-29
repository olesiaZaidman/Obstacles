using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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


    public Color targetColor = new Color(0.1313634f, 0.6766795f, 0.8490566f);
    private Color originalColor;
    public float colorChangeDuration = 1f;

    public UnityEvent penaltyAnim;
    public GameObject penaltyText;
    void Start()
    {
        originalColor = timeText.color;
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
                StartCoroutine(ChangeTextColorCoroutine());
                AddPenaltyTime();
                penaltyAnim.Invoke();
                isPenalty = false; // Reset the event flag
            }

            timeText.SetText(GetDisplayTime().ToString(@"mm\:ss"));
            //   Debug.Log("Current time: " + GetDisplayTime().ToString(@"hh\:mm\:ss\.fff"));
        }

        if (timerRunning && FinishLevelManager.IsFinishLevel)
        {
            StopTimer();
            SaveTimeScore();
        }
    }

    void AddPenaltyTime()
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
        LevelsData.SaveScoreOverallTime(finishTime);

        // FinishLevelManager.gameDurationInSeconds = (float)finishTime.TotalSeconds;
        //  Debug.Log("Your Score: " + finishTime.ToString(@"mm\:ss"));
        return finishTime;
    }

    TimeSpan GetDisplayTime()
    {
        return elapsedTime + penaltyTime;
    }

    private IEnumerator ChangeTextColorCoroutine()
    {
        // Change the color to the target color
        timeText.color = targetColor;

        // Wait for the specified duration
        yield return new WaitForSeconds(colorChangeDuration);

        // Revert the color back to the original color
        timeText.color = originalColor;
    }

    public void PlayPenaltyAnimation()
    {
        StartCoroutine(PlayPenaltyAnimationRotine());
    }
    public IEnumerator PlayPenaltyAnimationRotine()
    {
        penaltyText.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        penaltyText.SetActive(false);
    }
}
