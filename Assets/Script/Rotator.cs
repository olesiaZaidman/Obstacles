
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    int direction;
    float speed = 30f;
    void Start()
    {
        direction = GetRandomInt();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, direction, 0) * Time.deltaTime * speed, Space.World);
    }

    private int GetRandomInt()
    {
        float randomFloat = Random.Range(0f, 1f);

        int result = (randomFloat < 0.5f) ? -1 : 1;

        return result;
    }
}
