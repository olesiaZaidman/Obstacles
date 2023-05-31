using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI totalTimerText;
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
        SetTotalTimer(LevelsData.overallTime);
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

            SetTimerText(timeText, GetDisplayTime());
          //  SetTimerText(totalTimerText, LevelsData.overallTime);

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
        SetTotalTimer(LevelsData.overallTime);
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

    public void SetTotalTimer(TimeSpan _total)
    {
        totalTimerText.SetText(_total.ToString(@"mm\:ss"));
        ActivateGlow(totalTimerText);
       // DeactivateGlow(totalTimerText);
    }

    public void SetTimerText(TextMeshProUGUI _text, TimeSpan _time)
    {
        _text.SetText(_time.ToString(@"mm\:ss"));
    }

    public void ActivateGlow(TextMeshProUGUI _text)
    {
        Material material = _text.material;
     //   material.EnableKeyword("GLOW_ON");
        //material.DisableKeyword("GLOW_ON");
        //material.shader = Shader.Find("TextMeshPro/Distance Field Glow");
        //material.SetColor(ShaderUtilities.ID_GlowColor, Color.white);
        //material.SetFloat(ShaderUtilities.ID_GlowPower, 1.0f);
    }

    public void DeactivateGlow(TextMeshProUGUI _text)
    {
        Material material = _text.material;

     //  material.DisableKeyword("GLOW_ON");
        //Material material = _text.material;

        //// Set the shader back to the default TextMeshPro shader
        //material.shader = Shader.Find("TextMeshPro/Distance Field");

        //// Reset the Glow color
        //material.SetColor(ShaderUtilities.ID_GlowColor, Color.black);

        //// Reset the intensity of the Glow effect
        //material.SetFloat(ShaderUtilities.ID_GlowPower, 0.0f);
    }
}
