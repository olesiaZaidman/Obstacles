using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    Color bumpedColor = new Color(0.1313634f, 0.6766795f, 0.8490566f);
  //  Color wallsColor = new Color(0.4528302f, 0.3349234f, 0.4249049f);
  //  int score = 0;
    bool hasBumped = false;

    MeshRenderer mesh;
    AudioPlayer audioPlayer;
    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player") && !hasBumped)
        {
            hasBumped = true;
            mesh.material.color = bumpedColor;
            LevelsData.AddScore(100);
            audioPlayer.PlayCollisionSFX();
        }


        //or GetComponent<MeshRenderer>().material.color = bumpedColor; if code sits on the object itself
    }

  
}
