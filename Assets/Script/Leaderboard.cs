using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UIElements;
using System.Reflection;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI[] textResultSpots = new TextMeshProUGUI[LevelsData.maxScores];
    void Start()
    {
       ShowResults(LevelsData.finishScores);
    }


    void ShowResults(List<TimeSpan> finishScores)
    {
        for (int i = 0; i < textResultSpots.Length; i++)
        {
            if (i < finishScores.Count)
            {
                textResultSpots[i].SetText(finishScores[i].ToString(@"mm\:ss"));
                if (finishScores[i] == LevelsData.overallTime)
                {
                   // textResultSpots[i].material.color = Color.white;
                    textResultSpots[i].color = Color.yellow;
                }
                else
                {
                    textResultSpots[i].color = Color.white;
                }
            }
            else             
            {
                textResultSpots[i].SetText("00:00");    // OR textResultSpots[i].SetText(TimeSpan.Zero.ToString(@"mm\:ss"));
            }
        }

    }

    void ShowLatestResultInColor()
    {
       
    }


}
