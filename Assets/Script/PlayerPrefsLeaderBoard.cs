using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerPrefsLeaderBoard : MonoBehaviour
{
    public TextMeshProUGUI firstText;
    public TextMeshProUGUI secondText;
    public TextMeshProUGUI thirdText;
    public TextMeshProUGUI fourthText;
    public TextMeshProUGUI fifthText;

    //  private List<TimeSpan> savedTimeResults = new List<TimeSpan>(new TimeSpan[5]);

    //  public string[] formattedTimes;
    //  private List<float> savedTimes = new List<float>(new float[5]);
    void Start()
    {
        //  CheckIfPrefsSet();
        //    GetBestTimes();
     //   ShowResults();
    }


    //void GetBestTimes()
    //{
    //    if (PlayerPrefs.HasKey("fastTime1"))
    //    {
    //        savedTimes[0] = PlayerPrefs.GetFloat("fastTime1");
    //    }

    //    if (PlayerPrefs.HasKey("fastTime2"))
    //    {
    //        savedTimes[1] = PlayerPrefs.GetFloat("fastTime2");
    //    }

    //    if (PlayerPrefs.HasKey("fastTime3"))
    //    {
    //        savedTimes[2] = PlayerPrefs.GetFloat("fastTime3");
    //    }

    //    if (PlayerPrefs.HasKey("fastTime4"))
    //    {
    //        savedTimes[3] = PlayerPrefs.GetFloat("fastTime4");
    //    }

    //    if (PlayerPrefs.HasKey("fastTime5"))
    //    {
    //        savedTimes[4] = PlayerPrefs.GetFloat("fastTime5");
    //    }

    //    FormatTimesToString();
    //}

    //void FormatTimesToString()
    //{
    //    for (int i = 4; i >= 0; i--)
    //    {
    //        TimeSpan t = TimeSpan.FromSeconds(savedTimes[i]);
    //        formattedTimes[i] = t.ToString("mm' : 'ss' : 'ff");
    //    }
    //}

    //void ShowResults()
    //{
    //    DisplayTimeResult(firstText, LevelsData.ReturnData(0));
    //    DisplayTimeResult(secondText, LevelsData.ReturnData(1));
    //    DisplayTimeResult(thirdText, LevelsData.ReturnData(2));
    //    DisplayTimeResult(fourthText, LevelsData.ReturnData(3));
    //    DisplayTimeResult(fifthText, LevelsData.ReturnData(4));

    //    // savedTimeResults.Sort(TimeSpan.Compare);
    //    //   DisplayTimeResult(firstText, savedTimeResults[0]);
    //    // DisplayTimeResult(secondText, savedTimeResults[1]);
    //    // DisplayTimeResult(thirdText, savedTimeResults[2]);
    //    // DisplayTimeResult(fourthText, savedTimeResults[3]);
    //    //DisplayTimeResult(fifthText, savedTimeResults[4]);
    //}

    //void DisplayTimeResult(TextMeshProUGUI _text, TimeSpan _result)
    //{
    //    _text.SetText(_result.ToString(@"mm\:ss"));
    //}

    //void CheckIfPrefsSet()
    //{
    //    for (int i = 0; i <= 5; i++)
    //    {
    //        //if we dont have our PlayerPrefs set them with default value of 0
    //        if (!PlayerPrefs.HasKey("fastTime" + i.ToString()))
    //        {
    //            PlayerPrefs.SetFloat("fastTime" + i.ToString(), 0);
    //        }
    //    }
    //}


    //  public void CheckRaceTime() //NB!! Event should be raised everytime we finish the level
    //{
    //    int scorePosition = int.MaxValue;
    //    bool highScore = false;

    //    //loop backwards throught the savedTimes and check if have beaten any times 
    //    for (int i = 4; i >= 0; i--)
    //    {
    //        //check time and also check if time slot is unsaved
    //        if (ScoreManager.gameDurationInSeconds < savedTimes[i] || savedTimes[i] == 0)
    //        {
    //            highScore = true;
    //            //if it is less than our current position make that our current position
    //            if (i < scorePosition)
    //            {
    //                scorePosition = i;
    //            }
    //        }
    //    }

    //    //if we have high score insert it into our times list and then set the new best times  playerprefs
    //    if (highScore)
    //    {
    //        savedTimes.Insert(scorePosition, ScoreManager.gameDurationInSeconds);
    //        SetBestTimes();
    //    }
    //}

    //void SetBestTimes()
    //{
    //    PlayerPrefs.SetFloat("fastTime1", savedTimes[0]);
    //    PlayerPrefs.SetFloat("fastTime2", savedTimes[1]);
    //    PlayerPrefs.SetFloat("fastTime3", savedTimes[2]);
    //    PlayerPrefs.SetFloat("fastTime4", savedTimes[3]);
    //    PlayerPrefs.SetFloat("fastTime5", savedTimes[4]);
    //    FormatTimesToString();
    //}
}
