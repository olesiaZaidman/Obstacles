using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    Color succesColor = new Color(0.7254902f, 1f, 0f);
    Color finishFlagOriginColor = new Color(1f, 0f, 0.06907606f);
    MeshRenderer mesh;
   public ParticleSystem finishFX;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
      //  mesh.material.color = finishFlagOriginColor;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !ScoreManager.IsFinishLevel)
        {
            Debug.Log("Player finishes level!");
            mesh.material.color = succesColor;
            ScoreManager.FinishLevel();
            finishFX.Play();
        }
    }
}
