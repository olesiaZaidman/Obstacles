using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public GameObject overlayScreen;
    float sceneLoadDelay = 1f;
    float fadingTimeBudget = 1f;

    AudioPlayer audioPlayer;
 
    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();

        if (overlayScreen != null)
        { 
            overlayScreen.GetComponent<Image>().CrossFadeAlpha(0, fadingTimeBudget, false);
            audioPlayer.PlaySceneLoadedSFX();
        }      
    }


    void Update()
    {
    //    FadingTest();
    }

    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad(sceneLoadDelay));
    }

    IEnumerator WaitAndLoad(float _delay)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        float dificultyModifier = 0.5f;
        // Debug.Log("nextSceneIndex "+ nextSceneIndex);
        /*We calculate the index of the next scene by incrementing the current scene index by 1 and 
         * using the modulo operator (%) with SceneManager.sceneCountInBuildSettings. 
         * This ensures that the next scene index loops back to 0 if it exceeds the number of scenes in the build.*/




        if (overlayScreen != null)
        {
            overlayScreen.GetComponent<Image>().CrossFadeAlpha(1, fadingTimeBudget, false);
        }

        yield return new WaitForSeconds(_delay);

        print("nextSceneIndex to Load: " + nextSceneIndex);

        //if (nextSceneIndex == 1)
        //{
        //    LevelsData.RestartScore();
        //}


        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {            
            LevelsData.SaveData();
            print("Data is saved: " + LevelsData.overallTime);
        }
        if (currentSceneIndex > 0)
        {
            LevelsData.IncreaseGameDifficulty(dificultyModifier);
        }
        SceneManager.LoadScene(nextSceneIndex);
    }


    public void LoadScene(int _sceneIndex)
    {
        audioPlayer.PlayClickSFX();
        StartCoroutine(LoadScene(_sceneIndex, sceneLoadDelay));
    }

    public void QuitGame()
    {
        audioPlayer.PlayClickSFX();
        Application.Quit();
    }

    //public void PlayClick()
    //{
    //    audioPlayer.PlayClickSFX();
    //}


    IEnumerator LoadScene(int _sceneIndex, float _delay)
    {
        if (overlayScreen != null && _sceneIndex == 1)
        {
           overlayScreen.GetComponent<Image>().CrossFadeAlpha(1, fadingTimeBudget, false);
            LevelsData.RestartScore();
        }

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(_sceneIndex);
    }


    // void FadingTest() //In Update with bool m_Fading 
    //   {
    //if (m_Fading == true)
    //{
    //    //Fully fade in Image (1) with the duration of 2
    //    overlayScreen.GetComponent<Image>().CrossFadeAlpha(1, 1.0f, false);
    //}
    ////If the toggle is false, fade out to nothing (0) the Image with a duration of 2
    //if (m_Fading == false)
    //{
    //    overlayScreen.GetComponent<Image>().CrossFadeAlpha(0, 1.0f, false);
    //}
    // }
}
