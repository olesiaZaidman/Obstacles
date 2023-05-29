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

    void Awake()
    {
        if (overlayScreen != null)
        { 
            overlayScreen.GetComponent<Image>().CrossFadeAlpha(0, fadingTimeBudget, false); 
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
        // Debug.Log("nextSceneIndex "+ nextSceneIndex);
        /*We calculate the index of the next scene by incrementing the current scene index by 1 and 
         * using the modulo operator (%) with SceneManager.sceneCountInBuildSettings. 
         * This ensures that the next scene index loops back to 0 if it exceeds the number of scenes in the build.*/

        if (overlayScreen != null)
        {
            overlayScreen.GetComponent<Image>().CrossFadeAlpha(1, fadingTimeBudget, false);
        }

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(nextSceneIndex);
    }


    public void LoadScene(int _sceneIndex)
    {
        StartCoroutine(LoadScene(_sceneIndex, sceneLoadDelay));
    }


    IEnumerator LoadScene(int _sceneIndex, float _delay)
    {
        if (overlayScreen != null && _sceneIndex == 1)
        {
          overlayScreen.GetComponent<Image>().CrossFadeAlpha(1, fadingTimeBudget, false);
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
