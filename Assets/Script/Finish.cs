using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Finish : MonoBehaviour
{
    Color succesColor = new Color(0.7254902f, 1f, 0f);
    Color finishFlagOriginColor = new Color(1f, 0f, 0.06907606f);
    MeshRenderer mesh;
   public ParticleSystem finishFX;

    public UnityEvent finish;
    [SerializeField] AudioClip finishSFX;
   // AudioPlayer audioPlayer;
    AudioSource audioS; 
    void Awake()
    {
      //  audioPlayer = FindObjectOfType<AudioPlayer>();
        audioS = GetComponent<AudioSource>();    
    }
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
      //  mesh.material.color = finishFlagOriginColor;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !FinishLevelManager.IsFinishLevel)
        {
           // Debug.Log("Player finishes level!");
            mesh.material.color = succesColor;
            audioS.PlayOneShot(finishSFX, 0.6f);
         //   audioPlayer.PlayFinishSFX();

            FinishLevelManager.FinishLevel();
            finishFX.Play();
            finish.Invoke();
        }
    }
}
