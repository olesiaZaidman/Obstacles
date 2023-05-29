//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Position
{
    Left,
    Right,
    Center
}


public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject obstacleCubePrefab;
    public GameObject obstacleSpherePrefab;

    float startTime=1f;
    float repeatCubeTime = 3f;
    float repeatSphereTime = 5f;

 

    int randomIndex; // = Random.Range(0, 3);

    //Cube Spawn Positions:
    float xCubeCoordinate = 23; //   float xMin = -23;
    float yCubeCoordinate = 17.5f;
    float zMinCubeCoordinate = -22f;
    float zMaxCubeCoordinate = 23f;

    //Sphere Spawn Positions:
    float ySphereCoordinate = 16f;

    //Left:
    float xLeftConstSphereCoordinate = -47.8f;
    //Right:
    float xRightConstSphereCoordinate = 47;

    float zMinSphereCoordinate = -18f;
    float zMaxSphereCoordinate = 35f;

    //Center:
    float zCenterConstSphereCoordinate = 47;
    float xMinSphereCoordinate = -38;
    float xMaxSphereCoordinate = 40; 



    //Left: x = -47.8 ; zMinSphereCoordinate = -18f; zMaxSphereCoordinate = 35f;

    //Right: x=47 ; zMinSphereCoordinate = -18f; zMaxSphereCoordinate = 35f;

    //Center xMinSphereCoordinate = -38;xMaxSphereCoordinate = 40; z = 47



    void Start()
    {
        Debug.Log("Current Difficulty: "+ LevelsData.Difficulty);
        InvokeRepeating("SpawnCube", startTime, repeatCubeTime * LevelsData.Difficulty);
        InvokeRepeating("SpawnSphere", startTime, repeatSphereTime* LevelsData.Difficulty);
    }

    void SpawnCube()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-xCubeCoordinate, xCubeCoordinate), yCubeCoordinate, Random.Range(zMinCubeCoordinate, zMaxCubeCoordinate));
            //float is inclusive
       GameObject cubeInstance =  Instantiate(obstacleCubePrefab, spawnPosition, Quaternion.identity);
       cubeInstance.GetComponent<Rigidbody>().useGravity = false;
    }

    void SpawnSphere()
    {
        Position randomPosition = ChoosePosition();

        if (randomPosition == Position.Left)
        {
            Vector3 spawnPosition = new Vector3(xLeftConstSphereCoordinate, ySphereCoordinate, Random.Range(zMinSphereCoordinate, zMaxSphereCoordinate));
            Instantiate(obstacleSpherePrefab, spawnPosition, Quaternion.identity);
        }

        else if (randomPosition == Position.Right)
        {
            Vector3 spawnPosition = new Vector3(xRightConstSphereCoordinate, ySphereCoordinate, Random.Range(zMinSphereCoordinate, zMaxSphereCoordinate));
            Instantiate(obstacleSpherePrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Vector3 spawnPosition = new Vector3(Random.Range(xMinSphereCoordinate, xMaxSphereCoordinate), ySphereCoordinate, zCenterConstSphereCoordinate);
            Instantiate(obstacleSpherePrefab, spawnPosition, Quaternion.identity);
        }
    }

    Position ChoosePosition()
    {
        randomIndex = Random.Range(0, 3); //int is exclusive
        Position randomPosition = (Position)randomIndex;
        return randomPosition;
    }
    
}
