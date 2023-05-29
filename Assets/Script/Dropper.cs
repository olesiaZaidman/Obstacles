using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Dropper : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 3f;
    RaycastHit hit;
    //InnerWall
    void Update()
    {
        DestroyIfThereIsAWall();


        timer += Time.deltaTime;

        // Check if the timer has reached the desired interval
        if (timer >= interval)
        {
            // Call your function here
            ActivatedGravity();

            // Subtract the interval from the timer to ensure the next call happens after 5 seconds
            timer -= interval;
            //// OR Reset the timer
            //timer = 0f;
        }
    }

    void ActivatedGravity()
    {
     //   Debug.Log(Time.time);
        GetComponent<Rigidbody>().useGravity = true;
    }

    void DestroyIfThereIsAWall()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100f))
        {
            if (hit.transform.CompareTag("InnerWall"))
            {
                print("We hit the " + hit.transform.name+ " at " + hit.transform.position);
                Destroy(gameObject);
                //hit.transform.name//or hit.distance
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("InnerWall"))
        {
            Destroy(gameObject);
        }
    }
}
