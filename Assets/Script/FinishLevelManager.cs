using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelManager : MonoBehaviour
{
    static bool isFinishLevel = false;
    public static bool IsFinishLevel { get { return isFinishLevel; } }

    public static void FinishLevel()
    {
        isFinishLevel = true;
    }
    void Start()
    {
        RestartLevel();
    }

    void RestartLevel()
    {
        isFinishLevel = false;
    }

}
