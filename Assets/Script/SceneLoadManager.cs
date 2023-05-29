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
        overlayScreen.GetComponent<Image>().CrossFadeAlpha(0, fadingTimeBudget, false);
    }


    void Update()
    {
    //    FadingTest();
    }

    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad("Game", sceneLoadDelay));
    }

    IEnumerator WaitAndLoad(string _sceneName, float _delay)
    {
        overlayScreen.GetComponent<Image>().CrossFadeAlpha(1, fadingTimeBudget, false);
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_sceneName);
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
