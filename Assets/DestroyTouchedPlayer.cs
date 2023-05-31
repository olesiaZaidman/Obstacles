using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTouchedPlayer : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 2f);
        }
    }

}
