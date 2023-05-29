using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    static AudioPlayer instance;

    public AudioPlayer GetAudioPlayerInstance()
    { return instance; }

    [Header("UI")]
    [SerializeField]  AudioClip  click;
    [SerializeField] AudioClip sceneLoaded;
    [SerializeField][Range(0f, 1f)]  float  uiVolume;

    [Header("Score")]
    [SerializeField]  AudioClip  collisionSFX;
    [SerializeField] AudioClip smashSFX;
    [SerializeField]  AudioClip  finishSFX;
    [SerializeField][Range(0f, 1f)]  float gameFxVolume;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayCollisionSFX()
    {
        PlaySFXClip(collisionSFX, gameFxVolume);
    }

    public  void PlayFinishSFX()
    {
        PlaySFXClip(finishSFX, gameFxVolume);
    }

    public  void PlayClickSFX()
    {
        PlaySFXClip(click, uiVolume);
    }
    public void PlaySceneLoadedSFX()
    {
        PlaySFXClip(sceneLoaded, uiVolume);
    }

    public void PlaySmashSFX()
    {
        PlaySFXClip(smashSFX, gameFxVolume);
    }
    void PlaySFXClip(AudioClip _clip, float _volume)
    {
        Vector3 _cameraPosition = Camera.main.transform.position;
        if (_clip != null)
        {
            AudioSource.PlayClipAtPoint(_clip, _cameraPosition, _volume);
        }
    }
}
